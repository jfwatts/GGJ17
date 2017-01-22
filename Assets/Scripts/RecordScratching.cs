using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordScratching : MonoBehaviour {
	public AudioSource mySound;
	private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision other){
			GetComponent<RecordPlayer> ().enabled = true;
			this.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		if (timer > 0)
			timer -= Time.deltaTime;


		if (timer <= 0) {
			timer = 6f;
			mySound.Play ();
			GameObject lastPulse = (GameObject)Instantiate (GetComponent<RecordPlayer>().soundPulse, transform.position, transform.rotation);
			lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 2.5f;
			lastPulse.GetComponent<SoundPulse> ().decay = 4.3f;
			lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
		}
	}
}
