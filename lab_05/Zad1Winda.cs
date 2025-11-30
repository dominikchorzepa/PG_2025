using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    
    private bool isRunningRight = true; 
    private bool isRunningLeft = false;
    
    private float leftPosition;
    private float rightPosition;

    private Transform oldParent;

    void Start()
    {
        leftPosition = transform.position.x;
        rightPosition = transform.position.x + distance;
    }

    void Update()
    {
        if (!isRunning)
            return;

        Vector3 move = Vector3.right * elevatorSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        float x = transform.position.x;

        if (isRunningRight && x >= rightPosition)
        {
            transform.position = new Vector3(rightPosition, transform.position.y, transform.position.z);

            isRunningRight = false;
            isRunningLeft = true;
            elevatorSpeed = -Mathf.Abs(elevatorSpeed);
        }

        else if (isRunningLeft && x <= leftPosition)
        {
            transform.position = new Vector3(leftPosition, transform.position.y, transform.position.z);

            isRunningLeft = false;
            isRunningRight = true;      
            elevatorSpeed = Mathf.Abs(elevatorSpeed);
            isRunning = false;          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;

            if (!isRunning)
            {
                if (Mathf.Approximately(transform.position.x, leftPosition))
                {
                    isRunningRight = true;
                    isRunningLeft = false;
                    elevatorSpeed = Mathf.Abs(elevatorSpeed);
                }
                
                else if (Mathf.Approximately(transform.position.x, rightPosition))
                {
                    isRunningRight = false;
                    isRunningLeft = true;
                    elevatorSpeed = -Mathf.Abs(elevatorSpeed);
                }

                isRunning = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
