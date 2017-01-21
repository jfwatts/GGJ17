using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFade : MonoBehaviour {
	private Renderer myRend;
	public Color color1 = Color.black;
	public Color color2 = new Color(255,255,255,255);
	public float timer = 0;
	// Use this for initialization
	void Start () {
		myRend = GetComponent<Renderer> ();
		myRend.material.color = Color.Lerp (color1, color2, timer);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
			myRend.material.color = Color.Lerp (color1, color2, timer);
		}

		if (GetComponent<NewtonVR.NVRInteractableItem> () != null && GetComponent<NewtonVR.NVRInteractableItem> ().AttachedHand != null) {
			timer = 1;
		}
	}
}
