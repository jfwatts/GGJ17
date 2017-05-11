using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterPathing : MonoBehaviour {
	public GameObject soundPulse;
	public static Vector3 lastSound;
	public static MonsterPathing monsterAI;
	public float lastSoundStr;
	public float speedDecay = 50;
	public float noiseFrequency = 0.5f;
	private NavMeshAgent myNav;
	private float timer = 0;
	private float anotherTimer = 10;

	public GameObject deathSprite;
	public PlayerMove player;
	public Transform[] wanderTargets;
	public AudioSource mySound;
	public AudioClip[] sounds;
	public float speedMult = 1;
	public GameObject bigSound;
	// Use this for initialization
	void Start () {
		monsterAI = this;
		myNav = GetComponent<NavMeshAgent> ();
	}
	
	public void StartNoise() {
		StartCoroutine(DoNoiseThing());
	}
	IEnumerator DoNoiseThing() {
		for(int i = 0; i < 10; i++) {
			GameObject lastPulse = (GameObject)Instantiate(bigSound, transform.position, transform.rotation);
			yield return new WaitForSeconds(0.5f);
		}
	}
	void Update () {
		if (lastSoundStr < 0)
			lastSoundStr = 0;
		if (Input.GetKeyDown (KeyCode.I)) {
			StartCoroutine (KillPlayer());
		}
		if (timer > 0)
			timer -= Time.deltaTime;
		if (anotherTimer > 0)
			anotherTimer -= Time.deltaTime;
		if (anotherTimer <= 0) {
			anotherTimer = 10;
			Wander ();
		}

		if (timer <= 0 && myNav.speed > 0.1f) {
			timer = noiseFrequency;
			MakeNoise ();
		}
		myNav.SetDestination (lastSound);
		if(lastSoundStr > 0)
			lastSoundStr -= Time.deltaTime * speedDecay;
		myNav.speed = lastSoundStr * speedMult;
	}
	public void HeardSomething (Vector3 where, float strength){
		lastSound = where;
		timer = noiseFrequency;
		lastSoundStr = 0;
		lastSoundStr += strength;
	}
	void MakeNoise (){
		GameObject lastPulse = (GameObject)Instantiate (soundPulse, transform.position, transform.rotation);
		lastPulse.GetComponent<SoundPulseCheap> ().lifeSpan = 1;
		lastPulse.GetComponent<SoundPulse> ().decay = 6f;
		lastPulse.GetComponent<SoundPulseCheap> ().UpdateLifeSpan ();
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			StartCoroutine (KillPlayer());
		}
	}
	void Wander (){
		int rand = Random.Range (0, 100);
		if (rand < 33) {
			lastSound = wanderTargets [Random.Range (0, wanderTargets.Length)].position;
			lastSoundStr = 2;
		}
		if (rand < 50) {
			mySound.clip = sounds [Random.Range (0, sounds.Length)];
			mySound.Play ();
		}
	}
	IEnumerator KillPlayer(){
		deathSprite.SetActive (true);
		deathSprite.GetComponent<Animator> ().SetBool ("go", true);
		player.myBody.isKinematic = true;
		yield return new WaitForSeconds (2);
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}
}
