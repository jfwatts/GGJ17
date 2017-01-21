using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HandMenu : MonoBehaviour {
	public static bool objectSnapping = true;
	public static bool heldObjectPhysics = false;
	public static bool barMarkers = true;
	public Text tipText;
	public GameObject snappingOn;
	public GameObject snappingOff;
	public GameObject physicsOn;
	public GameObject physicsOff;
	public GameObject barMarkersOn;
	public GameObject barMarkersOff;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (objectSnapping && (!snappingOn.activeInHierarchy || snappingOff.activeInHierarchy)) {
			snappingOn.SetActive(true);
			snappingOff.SetActive(false);
		}
		if (!objectSnapping && (snappingOn.activeInHierarchy || !snappingOff.activeInHierarchy)) {
			snappingOn.SetActive(false);
			snappingOff.SetActive(true);
		}
		if (heldObjectPhysics && (!physicsOn.activeInHierarchy || physicsOff.activeInHierarchy)) {
			physicsOn.SetActive(true);
			physicsOff.SetActive(false);
		}
		if (!heldObjectPhysics && (physicsOn.activeInHierarchy || !physicsOff.activeInHierarchy)) {
			physicsOn.SetActive(false);
			physicsOff.SetActive(true);
		}
		if (barMarkers && (!barMarkersOn.activeInHierarchy || barMarkersOff.activeInHierarchy)) {
			barMarkersOn.SetActive(true);
			barMarkersOff.SetActive(false);
		}
		if (!barMarkers && (barMarkersOn.activeInHierarchy || !barMarkersOff.activeInHierarchy)) {
			barMarkersOn.SetActive(false);
			barMarkersOff.SetActive(true);
		}
	}
}
