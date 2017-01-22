using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPulseCheap : MonoBehaviour {
	public float lifeSpan = 1.0f;
	public float speed = 2.0f;
	public float pulseMulti;
	private Renderer myRend;
	private SoundPulse myPulse;
	public bool deadSound = false;
	// Use this for initialization
	void Start () {
		myPulse = GetComponent<SoundPulse> ();
		myRend = GetComponent<Renderer> ();
		if (!deadSound) {
			MonsterPathing.lastSound = transform.position;
			print ("noise made monster moving");
		}
		
		Invoke("Die", lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		myPulse.radius += Time.deltaTime * pulseMulti;
		transform.localScale = new Vector3(transform.localScale.x + (Time.deltaTime * speed),transform.localScale.y + (Time.deltaTime * speed),transform.localScale.z + (Time.deltaTime * speed));
		myRend.material.color = new Color (myRend.material.color.r, myRend.material.color.g, myRend.material.color.b, myRend.material.color.a - (Time.deltaTime * (1 / lifeSpan)));
	}

	void Die(){
		Destroy(gameObject);
	}
	public void UpdateLifeSpan(){
		CancelInvoke ();
		Invoke ("Die", lifeSpan);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.GetComponent<ColorFade>() != null) {
			other.gameObject.GetComponent<ColorFade> ().timer = 1;
		}
	}
}
