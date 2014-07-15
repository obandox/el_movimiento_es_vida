using UnityEngine;
using System.Collections;

/*

//TODO
[0] Fantasma estandar de patrones mas prefabs
[0] Prefabs Arboles


[0] Un Player que se mueva en mas rapido hacia adelante que hacia atras, que muera al colisionar con los fantasmas
[0] El player dispare flechas y debilite los fantasmas


[0] Que exista una linterna en el player que se recarge con una caja de almas o con los restos del alma de un fantasma muerto.
[0] Que exista una puerta de finalizacion del juego ubicada en lo mas lejano del mapa

[0] Las almas disminuyen mientras pasa el tiempo
[0] La luz de la linterna se atenua con la falta almas de la misma


-- Tree01Prefab
-- Grass01Prefab
-- Tile01Prefab
-- WorldWall01Prefab

-- Player01Prefab
-- Lantern01Prefab
-- Bow01Prefab
-- Arrow01Prefab
-- Ghost01Prefab
-- SoulsBox01Prefab
-- Soul01Prefab
-- EndGate01Prefab

//TODO
  -Jugador: cazadora
  -Fantasma: estandar
  -Linterna: estandar
  -Arco: estandar
  -CajaAlmas: estandar
  -Alma: estandar
  -Templo: estandar


*/
public class Main : MonoBehaviour {
	
	public static Main Shared;

	public bool callGameOver = false;
	public void GameOver(){
		if (callGameOver)
						return;
		PlayerController.Shared.gameObject.SendMessage ("PlayDie");
		AutoFade.LoadLevel("BadEnd", 1f, 1f, Color.black);
		callGameOver = true;
	}

	public void EndGame(){
		AutoFade.LoadLevel("BadEnd", 1f, 1f, Color.white);
	}

	// Use this for initialization
	void Awake () {
		Shared = this;
	}


	// Use this
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
