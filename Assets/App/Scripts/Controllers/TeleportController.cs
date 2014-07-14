using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

	public GameObject Ghost;
	public GameObject Aura;

	private GameObject Player;

	public float speed = 2f;

	private bool looking = false;

	private bool following = false;
	

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		Ghost = this.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Ghost == null) return;
		if (looking) Ghost.transform.LookAt(Player.transform.position);
		if(following) Ghost.transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}

	public void OnTriggerEnter(Collider colli){
		if(colli.gameObject.tag == "Player"){
			EnterPlayer();
		}


	}

	public void OnTriggerExit(Collider colli){
		if(colli.gameObject.tag == "Player"){
			ExitPlayer();
		}

	}

	public IEnumerator StopFollow(){
		yield return new WaitForSeconds(2f);
		following = false;
	}

	public void EnterPlayer(){
		StopAllCoroutines();
		looking = true;
		StartCoroutine(TeleportWorker());
	}
	public void ExitPlayer(){
		looking = false;
		StopAllCoroutines();
		StartCoroutine(StopFollow());

	}

	public IEnumerator TeleportWorker(){
		yield return new WaitForSeconds(1f);
		if(looking){
			transform.position = new Vector3(Player.transform.position.x+(Random.Range(0, 3)), Player.transform.position.y, Player.transform.position.z-6);
			Player.SendMessage("PlayTeleport");
			following = true;
			GameObject thisAura = Instantiate(Aura, transform.position, transform.rotation) as GameObject;
			yield return new WaitForSeconds(4f);
			Destroy(thisAura.gameObject);

		}
	}
}
