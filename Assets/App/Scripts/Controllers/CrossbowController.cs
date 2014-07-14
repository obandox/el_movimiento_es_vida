using UnityEngine;
using System.Collections;

public class CrossbowController : MonoBehaviour {
	
	public static CrossbowController Shared;
	void Awake()  {
		Shared = this;
	}
	public int arrows = 10;
	public float shootSpeede = 4.0f;
	public Transform arrowPrefab;
	public Transform crossBow;
	public Transform crossBowHolder;
	public Transform cursor = null;
	public Camera camera;
	public float maxYAngle = 30.0f;
	public float minYAngle = -0.0f;
	public bool freezX = false;
	public bool freezY = false;
	public bool freezZ = false;



	// Use this for initialization
	void Start () {
		if (crossBow == null) {
			crossBow = transform;
		}
		if (crossBowHolder == null) {
			crossBowHolder=crossBow;
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		string tag = hit.collider.tag;
		if(tag == "Arrow"){
			Destroy(hit.collider.gameObject);
			arrows += 1;
		}
	}

	// Update is called once per frame
	void Update () {
		
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			Vector3 targetPosition=new Vector3(hit.point.x, crossBow.position.y, hit.point.z);
			Vector3 eulers = crossBowHolder.eulerAngles;
			crossBowHolder.LookAt(targetPosition);
			
			if(!freezX){
				eulers.x = crossBowHolder.eulerAngles.x;
			}			
			if(!freezY){
				eulers.y = crossBowHolder.eulerAngles.y;
			}				
			if(!freezZ){
				eulers.z = crossBowHolder.eulerAngles.z;
			}
			
			crossBowHolder.eulerAngles = eulers;

			if(cursor!=null){
				cursor.position = targetPosition;
				cursor.LookAt(crossBow.position);
			}

			if(Input.GetButtonDown("Fire1")){
				if(arrows > 0){
					arrows-=1;
					gameObject.SendMessage("PlayArrow");
					var bullet = Instantiate(arrowPrefab,crossBow.transform.position,Quaternion.identity) as Transform;
					bullet.eulerAngles = crossBow.eulerAngles;
					var rigidBody = bullet.GetComponent<Rigidbody>();
					if(rigidBody!=null)            
						rigidBody.velocity = crossBow.transform.TransformDirection(new Vector3(0, 0,shootSpeede));
				}
				
			}


		}
	}
}
