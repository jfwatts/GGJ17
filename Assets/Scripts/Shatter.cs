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
			ShatterMe();
		}
	}

	public void ShatterMe (){
		GameObject lastSpawn = (GameObject)Instantiate (shatterModel, transform.position, transform.rotation);
		if (lastSpawn.GetComponent<AudioSource> () != null) {
			lastSpawn.GetComponent<AudioSource>().clip = sounds[Random.Range(0,sounds.Length)];
			lastSpawn.GetComponent<AudioSource>().Play();
		}
		lastSpawn.transform.parent = transform.parent;
		lastSpawn.transform.localScale = transform.localScale;
		Destroy(gameObject);
	}
}
