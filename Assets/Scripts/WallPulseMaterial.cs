using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WallPulseMaterial : MonoBehaviour {
    private Vector4[] centers = new Vector4[50];
    private float[] radiuses = new float[50];
    private float[] decays = new float[50];
    public bool turnTheLightsOn = false;
    public int numCircles = 3;
	public static Material[] mats = new Material[2];
	public  Material[] theMats = new Material[2];
    // Use this for initialization

    void Awake(){
        mats = theMats;
    }
    void Start () {
		mats = theMats;
        GameObject[] pulses = GameObject.FindGameObjectsWithTag("SoundPulse");
        int nPulses = Mathf.Min(pulses.Length, 50);
        for (int i = 0; i < nPulses; i++)
        {
            SoundPulse pulse = pulses[i].GetComponent<SoundPulse>();

            centers[i] = pulses[i].transform.position;
            radiuses[i] = pulse.radius;
            decays[i] = pulse.decay;
        }

        Shader.SetGlobalVectorArray("_gPulseCenters", centers);
        Shader.SetGlobalFloatArray("_gPulseRadiuses", radiuses);
        Shader.SetGlobalInt("_gNumPulses", nPulses);
        Shader.SetGlobalInt("_gLightsOn", turnTheLightsOn ? 1 : 0);
        Shader.SetGlobalInt("_gNumCircles", numCircles);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] pulses = GameObject.FindGameObjectsWithTag("SoundPulse");
        int nPulses = Mathf.Min(pulses.Length, 50);
        for (int i=0; i< nPulses; i++)
        {
            SoundPulse pulse = pulses[i].GetComponent<SoundPulse>();

            centers[i] = pulses[i].transform.position;
            radiuses[i] = pulse.radius;
            decays[i] = pulse.decay;
        }

       /* Renderer renderer = GetComponent<Renderer>();
        Material material = renderer.sharedMaterial;
        material.SetVectorArray("_PulseCenters", centers);
        material.SetFloatArray("_PulseRadiuses", radiuses);
        material.SetInt("_numPulses", nPulses);*/
        Shader.SetGlobalVectorArray("_gPulseCenters", centers);
        Shader.SetGlobalFloatArray("_gPulseRadiuses", radiuses);
        Shader.SetGlobalFloatArray("_gPulseDecayPower", decays);
        Shader.SetGlobalInt("_gNumPulses", nPulses);
        Shader.SetGlobalInt("_gLightsOn", turnTheLightsOn ? 1 : 0);
        Shader.SetGlobalInt("_gNumCircles", numCircles);
    }
}
