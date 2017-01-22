using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
	private SteamVR_TrackedObject myTrack;
	public int myIndex;
	public Transform myAnchor;
	public bool trigger;
	public bool grip;
	public bool isHoldingObject = false;
	public bool left = false;
	public GameObject theMenu;
	public GameObject Pointer;
	public GameObject soundPulse;
	private float snapTimer = 0;
	// Use this for initialization
	void Start () {
		myTrack = GetComponent<SteamVR_TrackedObject> ();
		myIndex = (int)myTrack.index;
	}
	
	// Update is called once per frame
	void Update () {
		if (snapTimer > 0)
			snapTimer -= Time.deltaTime;
		if (SteamVR_Controller.Input (myIndex).GetPress (SteamVR_Controller.ButtonMask.Grip)) {
			grip = true;
		} 
		else {
			grip = false;
		}


		if (SteamVR_Controller.Input (myIndex).GetPress (SteamVR_Controller.ButtonMask.Trigger)) {
			trigger = true;
			Pointer.SetActive (true);
		} 
		else if(!SteamVR_Controller.Input (myIndex).GetPress (SteamVR_Controller.ButtonMask.Trigger)){
			trigger = false;
			Pointer.SetActive(false);
		}


		if (SteamVR_Controller.Input (myIndex).GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu) && left) {
			if(theMenu.activeInHierarchy)
				theMenu.SetActive(false);
			else if(!theMenu.activeInHierarchy)
				theMenu.SetActive(true);
		}

		if ((SteamVR_Controller.Input (myIndex).GetPressDown (SteamVR_Controller.ButtonMask.Trigger) || Input.GetKeyDown(KeyCode.P))) {
			Snap ();
		}
	}

	void Snap(){
		//snapTimer = 0;
		GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
		SteamVR_Controller.Input(myIndex).TriggerHapticPulse(2000);
		lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 5.0f;
		lastPulse.GetComponent<SoundPulse> ().decay = 3.5f;
		MonsterPathing.monsterAI.HeardSomething (transform.position, 2);
		GetComponent<AudioSource> ().Play ();
	}

	void OnTriggerEnter(){
		SteamVR_Controller.Input(myIndex).TriggerHapticPulse(2000);
	}
}
