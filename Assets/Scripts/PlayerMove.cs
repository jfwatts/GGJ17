using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public Collider myCol;
	public static Collider playerCollider;
	public HandMovement myHand;
	public Rigidbody myBody;
	public Transform head;
	public float speed = 5;
	public Hand[] myHands;
    private WalkDetector walkDetector = null;
	public bool legacyMove = false;
	// Use this for initialization
	void Start () {
		playerCollider = myCol;
		myBody = GetComponent<Rigidbody> ();
        walkDetector = GetComponent<WalkDetector>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveManager ();
	}

	void MoveManager(){
		if (legacyMove) {
			float moveFlag = walkDetector.isWalking ? walkDetector.walkVelocity : myHand.touch.y;
			//Vector3 moveAdj = head.forward * myHand.touch.y * speed;
			Vector3 moveAdj = head.forward * moveFlag * speed;
			moveAdj += head.right * myHand.touch.x * speed;
			if (Mathf.Abs(myHand.touch.x) > 0.5f && Mathf.Abs(myHand.touch.y) > 0.5f)
				moveAdj *= 0.75f;
			moveAdj.y = myBody.velocity.y;
			myBody.velocity = moveAdj;
		}
		else if (!legacyMove) {
			float moveFlag = walkDetector.isWalking ? walkDetector.walkVelocity : myHand.touch.y;
			Vector3 moveAdj = Hand.moveHand.transform.forward * (myHand.touch.y * speed);
			//Vector3 moveAdj = head.forward * myHand.touch.y * speed;
			if (!HandMovement.handMovementPressed)
				moveAdj = Hand.moveHand.transform.forward * (moveFlag * speed);
			moveAdj += Hand.moveHand.transform.right * (myHand.touch.x * speed);
			if (Mathf.Abs(myHand.touch.x) > 0.5f && Mathf.Abs(myHand.touch.y) > 0.5f)
				moveAdj *= 0.75f;
			moveAdj.y = myBody.velocity.y;
			myBody.velocity = moveAdj;
		}
	}
	void OnCollisionEnter(){
		SteamVR_Controller.Input((int)myHands[0].myIndex).TriggerHapticPulse(3999);
		SteamVR_Controller.Input((int)myHands[1].myIndex).TriggerHapticPulse(3999);
	}
}
