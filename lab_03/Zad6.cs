using UnityEngine;

public class Zad6 : MonoBehaviour
{
    public Transform target;

    public bool useSmoothDamp = true;
    float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    public float lerpSpeed = 5.0f;

    void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 currentPosition = transform.position;

        if (useSmoothDamp)
        {
            transform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            transform.position = Vector3.Slerp(currentPosition, targetPosition, Time.deltaTime * lerpSpeed);
        }
    }
}