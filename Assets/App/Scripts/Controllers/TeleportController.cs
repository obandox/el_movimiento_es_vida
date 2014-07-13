using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

	public GameObject Ghost;
	public GameObject Aura;

	private GameObject Player;
	

	private bool looking = false;
	

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (looking) Ghost.transform.LookAt(Player.transform.position);
	}

	public void OnTriggerEnter(Collider colli){
		if(colli.gameObject.tag == "Player"){
			looking = true;

			StartCoroutine(TeleportWorker());
		}
		
	}

	public void OnTriggerExit(Collider colli){
		looking = false;
	}

	public IEnumerator TeleportWorker(){
		yield return new WaitForSeconds(1f);
		if(looking){
			transform.position = new Vector3(Player.transform.position.x+(Random.Range(0, 3)), Player.transform.position.y, Player.transform.position.z-4);
			GameObject thisAura = Instantiate(Aura, transform.position, transform.rotation) as GameObject;
			yield return new WaitForSeconds(4f);
			Destroy(thisAura.gameObject);
		}
	}
}
