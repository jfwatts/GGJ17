using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObjects : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand != null && GetComponent<Renderer> () != null && GetComponent<Renderer> ().material == WallPulseMaterial.mats [0]) {
			GetComponent<Renderer> ().material = WallPulseMaterial.mats [1];
		}
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand == null && GetComponent<Renderer> () != null && GetComponent<Renderer> ().material == WallPulseMaterial.mats [1]) {
			GetComponent<Renderer> ().material = WallPulseMaterial.mats [0];
		}
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand != null && GetComponentInChildren<Renderer> () != null && GetComponentInChildren<Renderer> ().material == WallPulseMaterial.mats [0]) {
			GetComponentInChildren<Renderer> ().material = WallPulseMaterial.mats [1];
		}
		if (GetComponent<NewtonVR.NVRInteractableItem>().AttachedHand == null && GetComponentInChildren<Renderer> () != null && GetComponentInChildren<Renderer> ().material == WallPulseMaterial.mats [1]) {
			GetComponentInChildren<Renderer> ().material = WallPulseMaterial.mats [0];
		}
	}
}
