using UnityEngine;
using System.Collections;

public class SoulController : MonoBehaviour {

	public static SoulController Shared;	
	void Awake(){
		Shared = this;
		
	}

	public float defaultSouls = 30;

	public float Souls = 30;
	public float DownSoul = 1.0f;
	
	public float AddSoul = 10;

	public float AddSoulbox = 40;
	
	public int SoulCount = 0;
	public int SoulboxCount = 0;
	
	public GameObject SoulPrefab;

	public Light[] Lights;
	private Hashtable hashLights= new Hashtable();

	public GameObject[] DisableOnDark;


	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		string tag = hit.collider.tag;		
		if(tag == "Soul"){
			if (Souls <= 0) Souls = 1;
			Destroy(hit.collider.gameObject);
			Souls+=AddSoul;
			SoulCount+=1;
		}else
		if(tag == "Soulbox"){
			if (Souls <= 0) Souls = 1;
			Transform child = hit.collider.transform.Search ("Particles");
			if(child != null){
				Destroy(child.gameObject);
				Souls+=AddSoulbox;
				SoulboxCount+=1;
				Camera.main.SendMessage("feedback");
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Souls -= DownSoul * Time.deltaTime;
		
		if (Souls <= 0) {
			foreach(GameObject obj in DisableOnDark){
				obj.SetActive(false);
			}		
		}else
		if (Souls > 0) {
			foreach(GameObject obj in DisableOnDark){
				obj.SetActive(false);
			}		
		}

		if (Souls <= -5f) {
			Main.Shared.GameOver();		
		}

		for(int i=Lights.Length-1; i>=0; i--){
			Light light = Lights[i];
			if(!hashLights.Contains(i))
				hashLights[i] = light.intensity;
			float intensityDefault = (float) hashLights[i];
			float unit = 1;
			if(defaultSouls > 0)
				unit = Souls / defaultSouls;
			light.intensity = Mathf.Clamp(unit * intensityDefault, 0, 8 );
		}

	}
}
