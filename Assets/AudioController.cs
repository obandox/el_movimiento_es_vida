using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	/*
	 * Orden de los Clips de Audio
	 * 0- Me miro el enemigo
	 * 1- Se teletransporto el enemigo
	 * 2- Tengo cerca a un PathGhost
	 * 3- Mate un fantasma
	 * 4- Me mori yo.
	 * 
	 * */

	public AudioClip[] audios;

	private AudioSource Source;

	// Use this for initialization
	void Start () {
		Source = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayLook(){
		Debug.Log("PlayLook");
		Source.clip = audios[0];
		Source.Play();
	}

	public void PlayTeleport(){
		Debug.Log("PlayTeleport");
		Source.clip = audios[1];
		Source.Play();
	}
}
