﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkDetector : MonoBehaviour {
    class MoveParams
    {
        public Vector4 p1Dir;
        public Vector4 p2Dir;
        public float timeStamp;
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
    public bool isWalking = false;


    // Use this for initialization
    void Start () {
		
	}
	
    void DetectWalk()
    {
        float time = Time.time;
        int yChanges1 = 0;
        int zChanges1 = 0;
        int yChanges2 = 0;
        int zChanges2 = 0;
        float yDist1 = 0;
        float zDist1 = 0;
        float yDist2 = 0;
        float zDist2 = 0;
        float minMoveDist = 0.3f;
        
        int i = 0;
        MoveParams lastPoint = null;
        foreach (MoveParams param in vecList)
        {
            if (i == 0)
            {
                lastPoint = param;
                i++;
                continue;
            }
            if (Mathf.Sign(lastPoint.p1Dir.y) != Mathf.Sign(param.p1Dir.y))
            {
                if (yDist1 * yDist1 > minMoveDist * minMoveDist)
                {
                    yChanges1++;
                }
                   
                yDist1 = 0;
            } else
            {
                yDist1 += param.p1Dir.y;
            }

            if (Mathf.Sign(lastPoint.p1Dir.z) != Mathf.Sign(param.p1Dir.z))
            {
                if (zDist1 * zDist1 > minMoveDist * minMoveDist)
                {
                    zChanges1++;
                }
             
                zDist1 = 0;
            } else
            {
                zDist1 += param.p1Dir.z;
            }
            if (Mathf.Sign(lastPoint.p2Dir.y) != Mathf.Sign(param.p2Dir.y))
            {
                if (yDist2 * yDist2 > minMoveDist * minMoveDist)
                {
                    yChanges2++;
                }
                yDist2 = 0;
            } else
            {
                yDist2 += param.p2Dir.y;
            }
            if (Mathf.Sign(lastPoint.p2Dir.z) != Mathf.Sign(param.p2Dir.z))
            {
                if (zDist2 * zDist2 > minMoveDist * minMoveDist)
                {
                    zChanges2++;
                }
                zDist2 = 0;
            } else
            {
                zDist2 += param.p2Dir.z;
            }

            lastPoint = param;
            i++;
            if (param.timeStamp < time - 0.5f)
            {
                break;
            }
        }

        if (yChanges1 > 0 && yChanges2 > 0 && Mathf.Sign(yDist1) != Mathf.Sign(yDist2))
        {
            isWalking = true;
        } else if (zChanges1 > 0 && zChanges2 > 0 && Mathf.Sign(zDist1) != Mathf.Sign(zDist2))
        {
            isWalking = true;
        } else
        {
            isWalking = false;
        }
        Debug.Log(isWalking);
        //Debug.Log("y: " + yDist1 + " z: " + zDist1);
        //Debug.Log("1 Y ch: " + yChanges1 + " 1 Z ch: " + zChanges1 + " 2 Y ch: " + yChanges2 + " 2 Z ch: " + zChanges2);
    }

	// Update is called once per frame
	void Update () {
        float time = Time.time;
        if (time < lastSampleTime + sampleRate)
        {
            return;
        }

        lastSampleTime = time;

        count++;
        if (count > 2)
        {
            MoveParams mParams = new MoveParams();
            mParams.p1Dir = palm1.transform.position - p1LastPos;
            mParams.p2Dir = palm2.transform.position - p2LastPos;
            mParams.timeStamp = time;

            vecList.AddFirst(mParams);

            if (count > maxHistory)
            {
                vecList.RemoveLast();
                count--;
            }
            DetectWalk();
        }

        p1LastPos = palm1.transform.position;
        p2LastPos = palm2.transform.position;
        


    }
}
