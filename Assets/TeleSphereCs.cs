using UnityEngine;
using System.Collections;

public class TeleSphereCs : MonoBehaviour {
	
	public void OnTriggerEnter(Collider coli){
		if (coli.tag == "Player") {
			transform.parent.GetComponent<TeleportController>().EnterPlayer();
		}
	}
	public void OnTriggerExit(Collider coli){
		if (coli.tag == "Player") {
			transform.parent.GetComponent<TeleportController>().ExitPlayer();
		}
	}

		

}
