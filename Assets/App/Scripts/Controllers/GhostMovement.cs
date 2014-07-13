using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {

	public enum GhostTypeMovement{
		PingPongMovement,
		CircularMovement
	}

	public string[] pathsNames;

	public int pathToUse;
	
	public Transform player;

	public int time;

	

	public GhostTypeMovement typeOfMovement;

	private Transform childDefault = null;

	// Use this for initialization
	public IEnumerator Start () {
		childDefault = transform.Search ("default");

		yield return StartCoroutine(BeginMovement());

	}
	
	
	// Update is called once per frame
	void Update () {
		if (player == null)
			player = PlayerController.Shared.transform;

		if (player != null && childDefault != null) {
			childDefault.LookAt(player.position);
		}
	}

	public IEnumerator BeginMovement(){
		if (pathsNames.Length > 0) {			
			if(typeOfMovement == GhostTypeMovement.PingPongMovement){
				iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathsNames[pathToUse]), "time", time, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.linear));
				iTween.RotateTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathsNames[pathToUse])));
			}else if(typeOfMovement == GhostTypeMovement.CircularMovement)
				iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathsNames[pathToUse]), "time", time, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear ));
		}

		yield return null;
	}
	

}
