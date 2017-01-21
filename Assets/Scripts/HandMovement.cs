using UnityEngine;
using System.Collections;

public class HandMovement : MonoBehaviour {
	public Vector2 touch;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		touch = SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index).GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
	}
}
