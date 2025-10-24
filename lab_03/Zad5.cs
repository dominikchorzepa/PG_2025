using System.Collections.Generic;
using UnityEngine;

public class Zad5 : MonoBehaviour 
{
    public GameObject myPrefab;

    public float planeSize = 10.0f;

    public int cubeCount = 10;

    private HashSet<Vector2> occupiedPositions = new HashSet<Vector2>();

    void Start()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = GetUniqueRandomPosition();

            if (randomPosition != Vector3.zero)
            {
                Instantiate(myPrefab, randomPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GetUniqueRandomPosition()
    {
        int maxAttempts = 100;

        Vector2 potentialXZ;

        for (int i = 0; i < maxAttempts; i++)
        {
            int randomX = Random.Range(-4, 6);
            int randomZ = Random.Range(-4, 6);

            potentialXZ = new Vector2(randomX, randomZ);

            if (!occupiedPositions.Contains(potentialXZ))
            {
                occupiedPositions.Add(potentialXZ);
                return new Vector3(randomX, 0.5f, randomZ);
            }
        }
        return Vector3.zero;
    }
}