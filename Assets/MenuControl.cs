using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {
	public string goTO = "Prueba01";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			AutoFade.LoadLevel(goTO, 1f, 0.5f, Color.black);
		}
	}
}
