using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gong : MonoBehaviour {
	public GameObject soundPulse;
	//public GameObject titan;
	//public GameObject mallet;
	
	//public bool deadSound = false;
	public GameObject player;
	public bool alreadyPlayed = false;
	public float frequency = 1;
	private float timer = 0;
	public AudioSource mySound;
	public AudioSource titan;
	public AudioClip[] audioClip;

	// Use this for initialization
	void Start ()
	{
		
	}
	void OnTriggerEnter(Collider other)
	{
		//print ("Gong Detect");
		if (other.gameObject.name == "Capsule") {
			print ("Gong Trigger Success");
			//print (other.gameObject.name);
			PlaySound(0);
			if (!alreadyPlayed)
				titan.Play ();
			alreadyPlayed = true;
			player.GetComponent<Rigidbody>().useGravity = false;		
		}
	}

	void PlaySound(int aclip)
	{
		mySound.clip = audioClip[aclip];
		mySound.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (alreadyPlayed)
		{
			player.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
			if (timer > 0)
				timer -= Time.deltaTime;
			if (timer <= 0) {
				timer = frequency;
				GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
				lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 16f;
				lastPulse.GetComponent<SoundPulse> ().decay = 1f;
				lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
			}
		}
	}
}


// public class RecordScratching : MonoBehaviour {
// 	public AudioSource mySound;
// 	private float timer = 0;
// 	// Use this for initialization
// 	void Start () {
		
// 	}

// 	void OnCollisionEnter(Collision other){
// 		if (other.gameObject.name != "Table" &&other.gameObject.name != "SoundPulse(Clone)") {
// 			print (other.gameObject.name);
// 			GetComponent<RecordPlayer> ().enabled = true;
// 			this.enabled = false;
// 		}
// 	}
// 	void OnTriggerEnter(Collider other){
// 		if (other.gameObject.name != "Table" &&other.gameObject.name != "SoundPulse(Clone)") {
// 			print (other.gameObject.name);
// 			GetComponent<RecordPlayer> ().enabled = true;
// 			this.enabled = false;
// 		}
// 	}
// 	// Update is called once per frame
// 	void Update () {
// 		if (timer > 0)
// 			timer -= Time.deltaTime;


// 		if (timer <= 0) {
// 			timer = 6f;
// 			mySound.Play ();
// 			GameObject lastPulse = (GameObject)Instantiate (GetComponent<RecordPlayer>().soundPulse, transform.position, transform.rotation);
// 			lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 2.5f;
// 			lastPulse.GetComponent<SoundPulse> ().decay = 4.3f;
// 			lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
// 		}
// 	}
// }