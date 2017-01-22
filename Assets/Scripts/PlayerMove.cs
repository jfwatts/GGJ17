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
        float moveFlag = walkDetector.isWalking ? walkDetector.walkVelocity : myHand.touch.y;
        //Vector3 moveAdj = head.forward * myHand.touch.y * speed;
        Vector3 moveAdj = head.forward * moveFlag * speed;
        moveAdj += head.right * myHand.touch.x * speed;
		if(Mathf.Abs(myHand.touch.x) > 0.5f && Mathf.Abs(myHand.touch.y) > 0.5f)
			moveAdj *= 0.75f;
		moveAdj.y = myBody.velocity.y;
		myBody.velocity = moveAdj;
	}
	void OnCollisionEnter(){
		SteamVR_Controller.Input(myHands[0]).TriggerHapticPulse(3999);
		SteamVR_Controller.Input(myHands[1]).TriggerHapticPulse(3999);
	}
}
