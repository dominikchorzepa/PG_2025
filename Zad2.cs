using UnityEngine;

public class Zad2 : MonoBehaviour {

    public float speed = 2.0f;

    public Vector3 startPosition;

    public Vector3 endPosition;

    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;

        endPosition = startPosition + new Vector3(10.0f, 0.0f, 0.0f);
    }
    
    void Update()
    {
        Vector3 targetPosition = movingForward ? endPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingForward = !movingForward;
        }
    }
}
