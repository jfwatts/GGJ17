using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour {
	public float lifeSpan = 2.0f;
	// Use this for initialization
	void Start () {
		Invoke ("Die", lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Die(){
		Destroy (gameObject);
	}
}
