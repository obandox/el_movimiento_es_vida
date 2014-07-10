using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {

	public enum GhostTypeMovement{
		PingPongMovement,
		CircularMovement
	}

	public string[] pathsNames;

	public int pathToUse;

	public int time;
	

	public GhostTypeMovement typeOfMovement;

	// Use this for initialization
	public IEnumerator Start () {
		yield return StartCoroutine(BeginMovement());
	}
	

	public IEnumerator BeginMovement(){
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathsNames[pathToUse]), "time", time));
		yield return null;
	}
	

}
