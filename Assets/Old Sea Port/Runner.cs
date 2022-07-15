using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    Vector3 lastPos;
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastPos, transform.position) * Time.deltaTime > 0.1)
        {
        }
    }
}
