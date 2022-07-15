using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public GameObject[] points;
    public GameObject[] looks;
    public float[] speeds;
    public float[] accels;
    public float[] waits;
    private int destPoint = 0;
    private float enableAt = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up or when done
        if (destPoint >= points.Length)
            return;

        // Set speed and acceleration
        agent.speed = speeds[destPoint];
        agent.acceleration = accels[destPoint];

        agent.autoBraking = true;

        // Set the agent to go to the currently selected destination.
        agent.SetDestination(points[destPoint].transform.position);

        // Enable later
        enableAt = Time.time + waits[destPoint];

        // Choose the next point in the array as the destination,
        destPoint++;
    }


    void Update()
    {
        // Resume
        if (enableAt <= Time.time)
        {
            GotoNextPoint();
        }

        // Look at point
        if (Vector3.Distance(transform.position, points[destPoint - 1].transform.position) < 3 && !looks[destPoint - 1].transform.position.Equals(Vector3.zero))
        {
            Quaternion ogRot = transform.rotation;
            transform.LookAt(new Vector3(looks[destPoint - 1].transform.position.x, transform.position.y, looks[destPoint - 1].transform.position.z));
            transform.rotation = Quaternion.Lerp(ogRot, transform.rotation, 0.99f);
        }
    }
}