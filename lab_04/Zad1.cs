using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int numberOfCubes = 10;
    public Material[] materials;
    private Bounds platformBounds;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        Renderer planeRenderer = GetComponent<Renderer>();
        this.platformBounds = planeRenderer.bounds;

        for (int i = 0; i < numberOfCubes; i++)
        {
            float randomX = Random.Range(this.platformBounds.min.x, this.platformBounds.max.x);
            float randomZ = Random.Range(this.platformBounds.min.z, this.platformBounds.max.z);

            float finalY = this.platformBounds.max.y + 0.5f;
            this.positions.Add(new Vector3(randomX, finalY, randomZ));
        }

        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);
            if (materials.Length > 0)
            {
                int randomMaterialIndex = Random.Range(0, materials.Length);
                Renderer blockRenderer = newBlock.GetComponent<Renderer>();
                if (blockRenderer != null)
                {
                    blockRenderer.material = this.materials[randomMaterialIndex];
                }
            }

            this.objectCounter++;
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
