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
			Instantiate (soundPulse, transform.position, transform.rotation);
			MonsterPathing.lastSoundStr = 1.5f;
		}
	}
}
