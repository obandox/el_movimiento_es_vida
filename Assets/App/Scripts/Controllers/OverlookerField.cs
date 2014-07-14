using UnityEngine;
using System.Collections;

public class OverlookerField : MonoBehaviour {
	public string enterAction;
	public string exitAction;
	// Use this for initialization

	public void OnTriggerEnter(Collider colli){
		if(colli.transform.tag == "Player"){
			transform.parent.gameObject.GetComponent<OverlookerController>().Follow();
		}
	}

}
