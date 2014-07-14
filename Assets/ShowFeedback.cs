using UnityEngine;
using System.Collections;

public class ShowFeedback : MonoBehaviour {

	public TextMesh texto;
	public TextMesh shadow;
	// Use this for initialization
	void Start () {
		texto.text = "";
		shadow.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void feedback(){
		StartCoroutine(FeedbackWorker());

	}

	public IEnumerator FeedbackWorker(){
		if(SoulController.Shared.SoulboxCount<7){
		texto.text = "Cajas de alma: "+SoulController.Shared.SoulboxCount+"/7";
		shadow.text = texto.text;
		}else{
			texto.text = "Solo falta ir al templo";
			shadow.text = texto.text;
		}
		yield return new WaitForSeconds(2f);
		texto.text = "";
		shadow.text = "";
	}
}
