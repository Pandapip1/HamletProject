using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffLight : MonoBehaviour
{
    public float[] waits;
    public GameObject light;
    private int index;
    private float idxTime;
    void Start()
    {
        light.SetActive(false);
    }

    void Update()
    {
        if (index < waits.Length && idxTime >= waits[index])
        {
            light.SetActive(index % 2 == 0);
            idxTime = 0;
            index += 1;
        }
        idxTime += Time.deltaTime;
    }
}
