using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVolumeGenerator : MonoBehaviour
{
    public GameObject volumePrefab; // Reference to the quad prefab
    public int numberOfVolumes = 10; // Number of quads to create
    public float distanceBetweenVolumes = 0.1f; // Distance between each quad
    public float scaleMultiplier = 1f; // Scale factor for subsequent quads

    private void Start()
    {
        // Calculate the half-width of the quad
        float halfQuadWidth = volumePrefab.transform.localScale.y * 0.5f;

        // Instantiate the first quad as a child of the specified object
        GameObject firstQuad = Instantiate(volumePrefab, transform);

        // Loop to create additional quads
        for (int i = 1; i < numberOfVolumes; i++)
        {
            // Calculate the position for the next quad (center-to-center)
            Vector3 nextQuadPosition = transform.position + transform.up * (i * distanceBetweenVolumes) + transform.up * halfQuadWidth;

            // Instantiate the next quad as a child of the specified object
            GameObject nextQuad = Instantiate(volumePrefab, transform);

            nextQuad.transform.position = nextQuadPosition;

            // Scale the next quad
            nextQuad.transform.localScale = firstQuad.transform.localScale * (i + 1) * scaleMultiplier;
        }
    }
}