using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCut : MonoBehaviour {
	private GameObject lastLink;
	public Transform otherHead;
	public float distancebetween;
	private bool closed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distancebetween = Vector3.Distance (transform.position, otherHead.position);
		if (distancebetween < 0.036 && !closed) {
			closed = true;
			print ("Chomp");
			if (lastLink != null) {
				ChainBreak.chainBreak.Break (lastLink);
				Destroy (gameObject);
			}
		}
		if (distancebetween > 0.036 && closed) {
			closed = false;
		}
	}
		
	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "Chainlink") {
			lastLink = other.gameObject;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.name == "Head1") {
			gameObject.name = "not cut";
		}

		if (other.gameObject.name == "Chainlink") {
			lastLink = null;
		}
	}
}
