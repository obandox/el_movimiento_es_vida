using UnityEngine;
using System.Collections;

public class OverlookerField : MonoBehaviour {
	public string enterAction;
	public string exitAction;
	// Use this for initialization

	public void OnTriggerEnter(Collider colli){
		transform.parent.gameObject.SendMessage(enterAction);
	}

	public void OnTriggerExit(Collider colli){
		transform.parent.gameObject.SendMessage(exitAction);
	}
}
