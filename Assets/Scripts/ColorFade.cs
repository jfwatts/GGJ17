using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFade : MonoBehaviour {
	private Renderer myRend;
	public Color color1;
	public Color color2;
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
	}
}
