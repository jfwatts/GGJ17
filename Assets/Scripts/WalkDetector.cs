using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkDetector : MonoBehaviour {
    public GameObject palm1;
    public GameObject palm2;
    private float sampleRate = 0.05f;
    private int maxHistory = 100;
    private LinkedList<Vector3> vecList = new LinkedList<Vector3>();
    int count = 0;
    float lastSampleTime = 0;
    Vector3 p1LastPos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float time = Time.time;
        if (time < lastSampleTime + sampleRate)
        {
            return;
        }

        lastSampleTime = time;

        vecList.AddFirst(palm1.transform.position);
        count++;
  
        if (count > maxHistory)
        {
            vecList.RemoveLast();
            count--;
        }
        Debug.Log(time);
        Debug.Log(count);
    }
}
