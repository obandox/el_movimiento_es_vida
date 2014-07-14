using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {
	
	public Texture Arrow;


	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI() {
		if(Arrow != null){
			int arrows = CrossbowController.Shared.arrows;
			Debug.Log(arrows);
			for(int i=0;i<arrows;i++){
				
				GUI.DrawTexture(new Rect(0+20*i, 0, 20, 120), Arrow);

			}

		}
	}
}
