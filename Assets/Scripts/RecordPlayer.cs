using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour {
	public GameObject soundPulse;
	public float frequency = 1;
	private float timer = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0)
			timer -= Time.deltaTime;

		if (timer <= 0) {
			timer = frequency;
			GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
			lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 2.5f;
			lastPulse.GetComponent<SoundPulse> ().decay = 4.3f;
			lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
		}
	}
}
