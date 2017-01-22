using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkDetector : MonoBehaviour {
    struct MoveParams
    {
        public Vector4 p1Dir;
        public Vector4 p2Dir;
    }

    public GameObject palm1;
    public GameObject palm2;
    private float sampleRate = 0.05f;
    private int maxHistory = 100;
    private LinkedList<MoveParams> vecList = new LinkedList<MoveParams>();
    int count = 0;
    float lastSampleTime = 0;
    Vector3 p1LastPos;
    Vector3 p2LastPos;



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
 
        MoveParams mParams = new MoveParams();
        mParams.p1Dir = palm1.transform.position - p1LastPos;
        mParams.p2Dir = palm2.transform.position - p2LastPos;
        p1LastPos = palm1.transform.position;
        p2LastPos = palm2.transform.position;

        vecList.AddFirst(mParams);
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
