using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public List<Transform> extraWaypoints = new List<Transform>();
    public bool startOnPlayerEnter = true;   

    private List<Vector3> points = new List<Vector3>(); 
    private int currentIndex = 0;                       
    private int direction = 1;                          
    private bool isRunning = false;

    private Transform oldParent;

    void Start()
    {
        
        points.Add(transform.position);

        foreach (Transform t in extraWaypoints)
        {
            if (t != null)
                points.Add(t.position);
        }

        if (!startOnPlayerEnter && points.Count > 1)
        {
            isRunning = true;
        }
    }

    void Update()
    {
        if (!isRunning)
            return;

        if (points.Count < 2)
            return;

        Vector3 targetPos = points[currentIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            currentIndex += direction;

            if (currentIndex >= points.Count)
            {
                direction = -1;
                currentIndex = points.Count - 2; 
            }
            
            else if (currentIndex < 0)
            {
                direction = 1;
                currentIndex = 1; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oldParent = other.transform.parent;
            other.transform.parent = transform;

            if (startOnPlayerEnter && !isRunning && points.Count > 1)
            {
                isRunning = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = oldParent;
        }
    }
}
