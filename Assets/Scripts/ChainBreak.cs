using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBreak : MonoBehaviour {
	public Rigidbody[] links;
	public static ChainBreak chainBreak;
	// Use this for initialization
	void Start () {
		chainBreak = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Break(GameObject which){
		foreach (Rigidbody body in links) {
			body.isKinematic = false;
		}
		Destroy (which);
	}
}
