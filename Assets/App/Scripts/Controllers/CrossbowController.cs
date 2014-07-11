using UnityEngine;
using System.Collections;

public class CrossbowController : MonoBehaviour {

	public float shootSpeede = 4.0f;
	public Transform arrowPrefab;
	public Transform crossBow;
	public Camera camera;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			var bullet = Instantiate(arrowPrefab,crossBow.transform.position,Quaternion.identity) as Transform;
			var rigidBody = bullet.GetComponent<Rigidbody>();
			if(rigidBody!=null)            
				rigidBody.velocity = crossBow.transform.TransformDirection(new Vector3(0, 0,shootSpeede));

		}
		
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
	}
}
