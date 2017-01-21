using UnityEngine;
using System.Collections;

public class HandModel : MonoBehaviour {
	private Hand myHand;
	private Animator myAnim;
	// Use this for initialization
	void Start () {
		myHand = transform.parent.GetComponent<Hand> ();
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myHand != null) {
			myAnim.SetBool("grab", myHand.grip);
		}
		if (myHand != null) {
			myAnim.SetBool("point", myHand.trigger);
		}
	}
}
