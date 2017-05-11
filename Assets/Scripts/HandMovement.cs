using UnityEngine;
using System.Collections;

public class HandMovement : MonoBehaviour {
	public Vector2 touch;
	public bool right;
	public static bool handMovementPressed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		touch = SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index).GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
		if (right) {
			if (Mathf.Abs(touch.x) < 0.1f && Mathf.Abs(touch.y) < 0.1f)
				handMovementPressed = false;
			else {
				handMovementPressed = true;
			}
		}
	}
}
