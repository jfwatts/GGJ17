using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustedFollow : MonoBehaviour {
	public float xAdj;
	public float yAdj;
	public float zAdj;
	public Transform target;
	public bool x;
	public bool y;
	public bool z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posAdj = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		if (x)
			posAdj.x = target.position.x + xAdj;
		if (y)
			posAdj.y = target.position.y + yAdj;
		if (z)
			posAdj.z = target.position.z + zAdj;
		transform.position = posAdj;
	}
}
