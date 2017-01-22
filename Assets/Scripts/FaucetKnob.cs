using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetKnob : MonoBehaviour {
	public NewtonVR.NVRInteractableItem knob;
	public Drip drip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand != null) {
			knob.enabled = false;
			drip.started = true;
			Destroy (gameObject, 0.1f);
		}
	}

	void OnTriggerEnter(Collider other){
		
	}
}
