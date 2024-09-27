using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public Transform target;
    public GameObject prefab;
    public float spawnDistance = 10f;
    public float spawnInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while(true){
            yield return SpawnAtDirection(Vector3.right); 
            yield return new WaitForSeconds(spawnInterval);

            yield return SpawnAtDirection(Vector3.left);  
            yield return new WaitForSeconds(spawnInterval);

            yield return SpawnAtDirection(Vector3.up);    
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private System.Collections.IEnumerator SpawnAtDirection(Vector3 direction)
    {
        if (target != null && prefab != null)
        {
            Vector3 spawnPosition = target.position + direction * spawnDistance;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
        yield return null; 
    }
}
