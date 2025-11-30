using UnityEngine;

public class DrzwiPrzesuwne : MonoBehaviour
{
    public Transform door;        
    public float openDistance = 2f; 
    public float moveSpeed = 3f; 

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private int playersInside = 0;
    private float stopThreshold = 0.001f;

    void Start()
    {
        if (door == null)
            door = transform;

        closedPosition = door.position;
        openPosition = closedPosition + transform.right * openDistance;
    }

    void Update()
    {
        Vector3 target = playersInside > 0 ? openPosition : closedPosition;

        if (Vector3.Distance(door.position, target) > stopThreshold)
        {
            door.position = Vector3.MoveTowards(door.position, target, moveSpeed * Time.deltaTime);
        }
        else
        {
            door.position = target;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersInside++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersInside = Mathf.Max(0, playersInside - 1);
        }
    }
}
