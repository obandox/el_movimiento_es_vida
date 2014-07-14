using UnityEngine;
using System.Collections;

public class PathGhostAdvert : MonoBehaviour {
	

	public void OnTriggerEnter(Collider colli){

		if(colli.gameObject.tag == "Player"){
			colli.gameObject.SendMessage("PlayClose");
		}
	}
}
