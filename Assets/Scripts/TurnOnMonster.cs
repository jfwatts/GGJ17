using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnMonster : MonoBehaviour {
	public SkinnedMeshRenderer render;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Floor") {
			render.enabled = true;
			Destroy(gameObject);
		}
	}
}
