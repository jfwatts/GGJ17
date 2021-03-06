﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlam : MonoBehaviour {
	private AudioSource mySound;
	public GameObject door;
	public NewtonVR.NVRInteractableItem knob1;
	public NewtonVR.NVRInteractableItem knob2;
	public GameObject monster;
	public bool alreadyPlayed = false;
	// Use this for initialization
	void Start () {
		mySound = door.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		//print ("something" + other.gameObject + " entered");
		if (!alreadyPlayed && (other.gameObject.CompareTag ("Player"))) {
			alreadyPlayed = true;
			print ("it was the player");
			mySound.Play ();
			door.transform.localPosition = Vector3.zero;
			door.transform.localEulerAngles = Vector3.zero;
			door.GetComponent<Rigidbody> ().isKinematic = true;
			// monster.GetComponent<MonsterPathing> ().speedDecay = 0.5f;
			// monster.GetComponent<AudioSource> ().Play ();
			knob1.enabled = false;
			knob2.enabled = false;
			Destroy (gameObject, 0.1f);
			print ("i got this far why the fuck did nothing happen");
		}
	}
}
