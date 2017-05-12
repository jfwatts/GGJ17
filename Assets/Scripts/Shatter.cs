using UnityEngine;
using System.Collections;

public class Shatter : MonoBehaviour {
	public GameObject shatterModel;
	public float shatterThreshold = 0;
	public bool testShatter;
	public AudioClip[] sounds;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (testShatter && Input.GetKeyDown (KeyCode.O)) {
			ShatterMe ();
		}
	}

	void OnCollisionEnter(Collision other){
		if (shatterThreshold != 0 && other.relativeVelocity.magnitude > shatterThreshold) {
			Invoke("ShatterMe", 0.1f);
		}
	}

	public void ShatterMe () {
		if (GetComponent<NewtonVR.NVRInteractableItem>() != null)
			GetComponent<NewtonVR.NVRInteractableItem>().EndInteraction();
		GameObject lastSpawn = (GameObject)Instantiate (shatterModel, transform.position, transform.rotation);
		if (lastSpawn.GetComponent<AudioSource> () != null) {
			lastSpawn.GetComponent<AudioSource>().clip = sounds[Random.Range(0,sounds.Length)];
			lastSpawn.GetComponent<AudioSource>().Play();
		}
		lastSpawn.transform.parent = transform.parent;
		lastSpawn.transform.localScale = transform.localScale;
		GetComponent<Renderer> ().enabled = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<Collider> ().isTrigger = true;
		Destroy(gameObject, 1);
	}
}
