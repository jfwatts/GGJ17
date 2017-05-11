using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripped : MonoBehaviour {
	public GameObject soundPulse;
	
	public bool deadSound = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision other){
		GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
		lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 5.0f;
		lastPulse.GetComponent<SoundPulse> ().decay = 3.5f;
		if (!deadSound)
			MonsterPathing.monsterAI.HeardSomething (transform.position, 2);		
		GetComponent<AudioSource> ().Play ();
		GetComponent<Rigidbody> ().isKinematic = true;
		Destroy (gameObject, 0.3f);
	}
}
