using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyplate : MonoBehaviour {
	public NewtonVR.NVRInteractableItem[] knobs;
	public GameObject knob;
	public GameObject key;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Key") {
			key.SetActive (true);
			Destroy (other.gameObject);
			knobs [0].enabled = true;
			knobs [1].enabled = true;
		}
		if (other.gameObject.name == "Knob") {
			Destroy (other.gameObject);
			knob.SetActive (true);
		}
	}
}
