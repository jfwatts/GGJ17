using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObjects : MonoBehaviour {
    // Use this for initialization
    private bool toggle = false;
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand != null && GetComponent<Renderer> () != null && !toggle) {
			GetComponent<Renderer> ().material = WallPulseMaterial.mats [1];
            toggle = !toggle;
            print("grabbed");
		}
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand == null && GetComponent<Renderer> () != null && toggle) {
			GetComponent<Renderer> ().material = WallPulseMaterial.mats [0];
            toggle = !toggle;
            print("dropped");
        }
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand != null && GetComponentInChildren<Renderer> () != null && !toggle) {
			GetComponentInChildren<Renderer> ().material = WallPulseMaterial.mats [1];
            toggle = !toggle;
            print("grabbed");
        }
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand == null && GetComponentInChildren<Renderer> () != null && toggle) {
			GetComponentInChildren<Renderer> ().material = WallPulseMaterial.mats [0];
            toggle = !toggle;
            print("dropped");
        }
	}
}
