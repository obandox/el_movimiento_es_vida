using UnityEngine;
using System.Collections;

public class CrossbowController : MonoBehaviour {
	
	public static CrossbowController Shared;

	public int arrows = 10;
	public float shootSpeede = 4.0f;
	public Transform arrowPrefab;
	public Transform crossBow;
	public Transform cursor = null;
	public Camera camera;
	public float maxYAngle = 30.0f;
	public float minYAngle = -0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			Vector3 targetPosition=new Vector3(hit.point.x, crossBow.position.y, hit.point.z);

			crossBow.LookAt(targetPosition);

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
