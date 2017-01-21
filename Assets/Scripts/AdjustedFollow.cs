using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustedFollow : MonoBehaviour {
	public float xAdj;
	public float yAdj;
	public float zAdj;
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x + xAdj, target.position.y + yAdj, target.position.z + zAdj);
	}
}
