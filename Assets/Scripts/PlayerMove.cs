using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public HandMovement myHand;
	private Rigidbody myBody;
	public Transform head;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoveManager ();
	}

	void MoveManager(){
		Vector3 moveAdj = head.forward * myHand.touch.y * speed;
		moveAdj += head.right * myHand.touch.x * speed;
		if(Mathf.Abs(myHand.touch.x) > 0.5f && Mathf.Abs(myHand.touch.y) > 0.5f)
			moveAdj *= 0.75f;
		moveAdj.y = myBody.velocity.y;
		myBody.velocity = moveAdj;
	}
}
