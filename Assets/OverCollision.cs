using UnityEngine;
using System.Collections;

public class OverCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnCollisionEnter(Collision collision) {

		if (collision.collider.tag == "Arrow") {
						Instantiate (SoulController.Shared.SoulPrefab, transform.position, Quaternion.identity);
						Destroy (gameObject);
		} else 
		if (collision.collider.tag == "Player") {
			Main.Shared.GameOver();
		}
	}
}
