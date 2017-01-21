using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSpaceFlight : MonoBehaviour {
	private NewtonVR.NVRInteractableItem me;
	private bool toggle = false;
	// Use this for initialization
	void Start () {
		me = GetComponent<NewtonVR.NVRInteractableItem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (me.AttachedHand != null && !toggle) {
			Physics.IgnoreCollision (GetComponent<Collider> (), PlayerMove.playerCollider, true);
			toggle = true;
		}
		if (me.AttachedHand == null && toggle) {
			toggle = false;
			Physics.IgnoreCollision (GetComponent<Collider> (), PlayerMove.playerCollider, false);
		}
	}
}
