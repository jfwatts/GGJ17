using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {
	public GameObject soundPulse;
	public GameObject monster;
	
	public bool deadSound = false;
	public bool alreadyPlayed = false;
	public float frequency = 1;
	private float timer = 1;
	public AudioSource mySound;

	public AudioClip[] audioClip;

	// Use this for initialization
	void Start ()
	{
		//tvaudio.playOnAwake () = false;
		//tvaudio.loop () = true;
	}
	void OnTriggerEnter(Collider other)
	{
		if (!alreadyPlayed && other.transform.tag == "PlayerHand") {
			print ("TV Trigger Success");
			//print (other.gameObject.name);
			if (!deadSound && monster.GetComponent<MonsterPathing>().enabled)
				MonsterPathing.monsterAI.HeardSomething (transform.position, 3);
			PlaySound(1);
			alreadyPlayed = true;
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
			if (timer > 0)
					timer -= Time.deltaTime;
			if (timer <= 0) {
				timer = frequency;
				GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
				lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 4f;
				lastPulse.GetComponent<SoundPulse> ().decay = 5f;
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