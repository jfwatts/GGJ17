﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPulser : MonoBehaviour {
	public GameObject soundPulser;
	public float multi = 1.0f;
	private AudioSource mySound;
	private float timer = 0;
	public float cooldown = 1.0f;
	public bool player = false;
	// Use this for initialization
	void Start () {
		if(GetComponent<AudioSource>() != null)
			mySound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0)
			timer -= Time.deltaTime;
	}

	void OnCollisionEnter (Collision other){
		if(!(gameObject.tag == "Player" && other.gameObject.tag == "Floor") && timer <= 0){
			timer = cooldown;
			GameObject lastPulse = (GameObject)Instantiate (soundPulser, other.contacts [0].point, transform.rotation);
			MonsterPathing.monsterAI.HeardSomething (transform.position, GetComponent<Rigidbody> ().velocity.magnitude * multi);
			lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = GetComponent<Rigidbody> ().velocity.magnitude * multi;
			if (player)
				lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 4;
			lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
			if (mySound != null) {
				mySound.Play ();
			}
		}
	}
}
