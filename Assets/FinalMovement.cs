using UnityEngine;
using System.Collections;

public class FinalMovement : MonoBehaviour {

	public float time;
	// Use this for initialization
	void Start () {
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("intro"), "time", time, "easetype", iTween.EaseType.linear));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
