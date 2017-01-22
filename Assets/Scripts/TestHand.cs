using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHand : MonoBehaviour {
	public GameObject soundPulse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			print ("snap");
			GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
			MonsterPathing.lastSoundStr = 1.5f;
			lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 5.0f;
			lastPulse.GetComponent<SoundPulse> ().decay = 4f;
		}
	}
}
