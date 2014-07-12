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
		if(typeOfMovement == GhostTypeMovement.PingPongMovement){
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathsNames[pathToUse]), "time", time, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.linear));
			iTween.RotateTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathsNames[pathToUse])));
		}else if(typeOfMovement == GhostTypeMovement.CircularMovement)
			iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathsNames[pathToUse]), "time", time, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear ));
		yield return null;
	}
	

}
