using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drip : MonoBehaviour {
	public GameObject drip;
	public float distractTime;
	public bool started = false;
	public float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (distractTime > 0 && started)
			distractTime -= Time.deltaTime;
		if (timer > 0 && started)
			timer -= Time.deltaTime;
		if (timer <= 0 && started) {
			timer = 5;
			GameObject lastDrip = (GameObject)Instantiate (drip, transform.position, transform.rotation);
			if (distractTime <= 0)
				lastDrip.GetComponent<Dripped> ().deadSound = true;
		}
	}
}
