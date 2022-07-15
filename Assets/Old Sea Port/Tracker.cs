using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class Tracker : MonoBehaviour
{
    public GameObject[] points;
    public GameObject[] looks;
    public float[] lerpMins;
    public float[] lerpMaxs;
    public float[] waits;
    private int destPoint = 0;
    private float enableAt = 0;
    private GameObject targetPos;
    private GameObject targetLook;
    private Vector3 targetPosVec;
    private Vector3 targetLookVec;


    void Start()
    {
        targetPos = points[destPoint];
        targetLook = looks[destPoint];
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up or when done
        if (destPoint >= points.Length)
            return;

        enableAt = Time.time + waits[destPoint];
        targetPos = points[destPoint];
        targetLook = looks[destPoint];

        // Choose the next point in the array as the destination,
        destPoint++;
    }


    void Update()
    {
        // Position
        targetPosVec = targetPos.transform.position;
        Quaternion ogRot = transform.rotation;
        transform.LookAt(targetLook.transform.position);
        var pct = Mathf.Clamp(lerpMaxs[Math.Min(destPoint, lerpMins.Length-1)] / Vector3.Distance(transform.position, targetPosVec), lerpMins[Math.Min(destPoint, lerpMins.Length-1)], lerpMaxs[Math.Min(destPoint, lerpMins.Length-1)]);
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, targetPosVec, pct), Quaternion.Lerp(ogRot, transform.rotation, pct));

        // Resume
        if (enableAt <= Time.time)
        {
            GotoNextPoint();
        }
    }
}