using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchMultiplier = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveWithCharacterController mover = other.GetComponent<MoveWithCharacterController>();
            if (mover != null)
            {
                mover.LaunchUp(launchMultiplier);
            }
        }
    }
}
