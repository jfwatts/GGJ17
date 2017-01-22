using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterPathing : MonoBehaviour {
	public GameObject soundPulse;
	public static Vector3 lastSound;
	public static MonsterPathing monsterAI;
	public float lastSoundStr;
	public float speedDecay = 0.7f;
	public float noiseFrequency = 0.5f;
	private NavMeshAgent myNav;
	private float timer = 0;
	private float anotherTimer = 0;
	// Use this for initialization
	void Start () {
		monsterAI = this;
		myNav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0)
			timer -= Time.deltaTime;
		if (anotherTimer > 0)
			anotherTimer -= Time.deltaTime;
		if (timer <= 0 && myNav.speed > 1) {
			timer = noiseFrequency;
			MakeNoise ();
		}
		myNav.SetDestination (lastSound);
		if(lastSoundStr > 0)
			lastSoundStr -= Time.deltaTime * speedDecay;
		myNav.speed = lastSoundStr;
	}
	public void HeardSomething (Vector3 where, float strength){
		lastSound = where;
		timer = noiseFrequency;
		lastSoundStr = strength;
	}
	void MakeNoise (){
		GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
		lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 1;
		lastPulse.GetComponent<SoundPulse> ().decay = 6f;
		lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
	}
}
