using UnityEngine;
using System.Collections;

public class HandMenuButton : MonoBehaviour {
	public int myFunction = 0;
	// Function list:
	// 0 = object snapping on
	// 1 = object snapping off
	// 2 = object physics on
	// 3 = object physics off
	// 4 = bar markers on
	// 5 = bar markers off
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Finger")){
			DoMyThing();
		}
	}

	void DoMyThing(){
		if (myFunction == 0) {
			HandMenu.objectSnapping = true;
		}
		else if (myFunction == 1) {
			HandMenu.objectSnapping = false;
		}
		else if (myFunction == 2) {
			HandMenu.heldObjectPhysics = true;
		}
		else if (myFunction == 3) {
			HandMenu.heldObjectPhysics = false;
		}
		else if (myFunction == 4) {
			HandMenu.barMarkers = true;
		}
		else if (myFunction == 5) {
			HandMenu.barMarkers = false;
		}
	}
}
