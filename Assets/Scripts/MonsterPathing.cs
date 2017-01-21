using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterPathing : MonoBehaviour {
	public static Vector3 lastSound;
	public static float lastSoundStr;
	public float speedDecay = 0.7f;
	private NavMeshAgent myNav;
	// Use this for initialization
	void Start () {
		myNav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		myNav.SetDestination (lastSound);
		if(lastSoundStr > 0)
			lastSoundStr -= Time.deltaTime * speedDecay;
		myNav.speed = lastSoundStr;
	}
}
