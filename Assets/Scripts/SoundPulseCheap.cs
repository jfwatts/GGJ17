using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPulseCheap : MonoBehaviour {
	public float lifeSpan = 1.0f;
	public float speed = 2.0f;
	private Renderer myRend;

	// Use this for initialization
	void Start () {
		MonsterPathing.lastSound = transform.position;
		myRend = GetComponent<Renderer> ();
		Invoke("Die", lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(transform.localScale.x + (Time.deltaTime * speed),transform.localScale.y + (Time.deltaTime * speed),transform.localScale.z + (Time.deltaTime * speed));
		myRend.material.color = new Color (myRend.material.color.r, myRend.material.color.g, myRend.material.color.b, myRend.material.color.a - (Time.deltaTime * (1 / lifeSpan)));
	}

	void Die(){
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.GetComponent<ColorFade>() != null) {
			other.gameObject.GetComponent<ColorFade> ().timer = 1;
		}
	}
}
