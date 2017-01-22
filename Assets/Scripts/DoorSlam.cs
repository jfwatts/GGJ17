using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlam : MonoBehaviour {
	private AudioSource mySound;
	public GameObject door;
	// Use this for initialization
	void Start () {
		mySound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			mySound.Play ();
			door.transform.position = Vector3.zero;
			door.transform.eulerAngles = Vector3.zero;
			door.GetComponent<Rigidbody>().isKinematic = true;;
		}
	}
}
