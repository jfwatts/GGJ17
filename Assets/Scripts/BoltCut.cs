using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCut : MonoBehaviour {
	private GameObject lastLink;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Head1") {
			print ("CHOMP");
			if (lastLink != null) {
				ChainBreak.chainBreak.Break (lastLink);
				Destroy (gameObject);
			}
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
