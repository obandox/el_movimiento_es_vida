using UnityEngine;
using System.Collections;

public class OverlookerController : MonoBehaviour {

	public GameObject Player {get; set;}

	private bool looking = false;

	private bool following = false;

	public GameObject myGhost;

	public float speed;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(myGhost == null) return;
		 myGhost.transform.LookAt(Player.transform.position);

		if(following) myGhost.transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}

	public void Look(){
		if(!looking){
			Debug.Log("Sended");
			Player.SendMessage("PlayLook");
			looking = true;
		}

	}


	public void Follow(){
		following = true;
	}
}
