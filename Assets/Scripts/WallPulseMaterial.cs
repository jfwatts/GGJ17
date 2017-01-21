using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WallPulseMaterial : MonoBehaviour {
    private Vector4[] centers = new Vector4[20];
    private float[] radiuses = new float[20];
    // Use this for initialization
    void Start () {
        GameObject[] pulses = GameObject.FindGameObjectsWithTag("SoundPulse");
        int nPulses = pulses.Length;
        for (int i = 0; i < pulses.Length; i++)
        {
            centers[i] = pulses[i].transform.position;
            radiuses[i] = pulses[i].GetComponent<SoundPulse>().radius;
        }

        /*  Renderer renderer = GetComponent<Renderer>();
          Material material = renderer.sharedMaterial;
          material.SetVectorArray("_PulseCenters", centers);
          material.SetFloatArray("_PulseRadiuses", radiuses);
          material.SetInt("_numPulses", nPulses);*/
        Shader.SetGlobalVectorArray("_gPulseCenters", centers);
        Shader.SetGlobalFloatArray("_gPulseRadiuses", radiuses);
        Shader.SetGlobalInt("_gNumPulses", nPulses);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] pulses = GameObject.FindGameObjectsWithTag("SoundPulse");
        int nPulses = pulses.Length;
        for (int i=0; i<pulses.Length; i++)
        {
            centers[i] = pulses[i].transform.position;
            radiuses[i] = pulses[i].GetComponent<SoundPulse>().radius;
        }

       /* Renderer renderer = GetComponent<Renderer>();
        Material material = renderer.sharedMaterial;
        material.SetVectorArray("_PulseCenters", centers);
        material.SetFloatArray("_PulseRadiuses", radiuses);
        material.SetInt("_numPulses", nPulses);*/
        Shader.SetGlobalVectorArray("_gPulseCenters", centers);
        Shader.SetGlobalFloatArray("_gPulseRadiuses", radiuses);
        Shader.SetGlobalInt("_gNumPulses", nPulses);
    }
}
