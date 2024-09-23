using UnityEngine;
using System.Collections.Generic;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public int numberOfObjects = 6;
    public float minDistance = 0.6f;
    private Vector3 spawnAreaSize;
    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        MeasureFloorSize();
        SpawnObjects();
    }

    void MeasureFloorSize()
    {
        Collider floorCollider = GetComponent<Collider>();
        if (floorCollider != null)
        {
            spawnAreaSize = floorCollider.bounds.size;
        }
        else
        {
            Debug.LogWarning("바닥에 Collider가 없습니다.");
            spawnAreaSize = new Vector3(5, 1, 5);
        }
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition;
            int attempts = 0; // 시도 횟수 카운트

            do
            {
                randomPosition = new Vector3(
                    transform.position.x + Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                    0.2f,
                    transform.position.z + Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
                );

                attempts++;

                if (attempts > 100) // 최대 시도 횟수
                {
                    Debug.LogWarning("최대 시도 횟수를 초과했습니다. 오브젝트 생성 중단.");
                    return; // 더 이상 생성하지 않음
                }

            } while (!IsPositionValid(randomPosition));

            spawnedPositions.Add(randomPosition);
            GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Instantiate(randomObject, randomPosition, Quaternion.identity);
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 spawnedPosition in spawnedPositions)
        {
            if (Vector3.Distance(position, spawnedPosition) < minDistance)
            {
                return false;
            }
        }
        return true;
    }
}
