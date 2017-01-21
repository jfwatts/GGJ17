using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionTarget : MonoBehaviour {
	public Collider target;
	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision (GetComponent<Collider> (), target, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
