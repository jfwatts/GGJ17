using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkylightBreak : MonoBehaviour {
	private AudioSource mySound;
	private AudioSource floorSound;
	public GameObject floorSpeaker;
	public GameObject skylight;
	public GameObject monster;
	public GameObject ragBone;
	public GameObject soundPulse;
	public bool alreadyPlayed = false;
	// Use this for initialization
	void Start () {
		mySound = skylight.GetComponent<AudioSource> ();
		floorSound = floorSpeaker.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnTriggerEnter(Collider other){
		//print ("something entered skylight");
		if (!alreadyPlayed && (other.gameObject.CompareTag ("Player"))) {
			alreadyPlayed = true;
			print ("SKYLIGHT BREAKING");
			mySound.Play ();
			ragBone.GetComponent<Cloth>().useGravity = true;
			floorSound.Play ();
			GameObject lastPulse = (GameObject)Instantiate (soundPulse, floorSpeaker.transform.position, floorSpeaker.transform.rotation);
			lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 6f;
			lastPulse.GetComponent<SoundPulse> ().decay = 6f;
			lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
			//monster.GetComponent<Renderer>().enabled = true;
			yield return new WaitForSeconds (1f);
			monster.GetComponent<MonsterPathing>().enabled = true;
			monster.GetComponent<MonsterPathing>().speedDecay = 0.5f;
			monster.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject, 0.1f);
		}
	}
}
