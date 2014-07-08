using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {

	public enum GhostType{
		PingPongMovement,
		CircularMovement
	}

	private Vector3 startPosition = new Vector3();

	public GameObject[] targetsPosition;
	public float time ;

	public GhostType typeOfGhost;

	// Use this for initialization
	public IEnumerator Start () {
		startPosition = transform.localPosition;
		yield return StartCoroutine(BeginMovement());
	}

	public IEnumerator BeginMovement(){
		int it = 0;
		int augmenter = 1;
		while(true){
			if(targetsPosition.Length>0){
				Debug.Log (it);
				Vector3 actualTarget = targetsPosition[it].transform.localPosition;
				iTween.MoveTo(this.gameObject, targetsPosition[it].transform.localPosition, time/targetsPosition.Length);
				while(transform.localPosition != targetsPosition[it].transform.localPosition) yield return null;
				Debug.Log("Next target "+it);
				it+= augmenter;
					
				if(it == targetsPosition.Length || it == 0){
					if(typeOfGhost == GhostType.CircularMovement) it = 0;
					else {
						augmenter = augmenter * -1;
						it += augmenter; 
					}
				}
			}
		}
	}
	

}
