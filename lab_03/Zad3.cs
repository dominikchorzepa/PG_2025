using UnityEngine;

public class Zad3 : MonoBehaviour {

    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;
    public float sideLength = 10.0f;

    public Vector3 targetPosition;
    public Quaternion targetRotation;

    private bool isMoving = true;

    void Start()
    {
        targetPosition = transform.position + transform.forward * sideLength;

        targetRotation = transform.rotation;
    }
    
    void Update()
    {
        if (isMoving)
        {
            if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                transform.position = targetPosition;
                isMoving = false;
                targetRotation = transform.rotation * Quaternion.Euler(0.0f, 90.0f, 0.0f);
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isMoving = true;
                targetPosition = transform.position + transform.forward * sideLength;
            }
        }
    }
}
