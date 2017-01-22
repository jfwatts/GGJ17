using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTheThing : MonoBehaviour {
	public float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0, speed * Time.deltaTime);
	}
}
