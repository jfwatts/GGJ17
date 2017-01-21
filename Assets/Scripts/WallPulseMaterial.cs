using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPulseMaterial : MonoBehaviour {
    private Vector4[] centers = new Vector4[20];
    private float[] radiuses = new float[20];
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] pulses = GameObject.FindGameObjectsWithTag("SoundPulse");
        int nPulses = pulses.Length;
        Debug.Log(nPulses);
        for (int i=0; i<pulses.Length; i++)
        {
            centers[i] = pulses[i].transform.position;
            radiuses[i] = pulses[i].GetComponent<SoundPulse>().radius;
        }

        Renderer renderer = GetComponent<Renderer>();
        Material material = renderer.sharedMaterial;
        material.SetVectorArray("_PulseCenters", centers);
        material.SetFloatArray("_PulseRadiuses", radiuses);
        material.SetInt("_numPulses", nPulses);
    }
}
