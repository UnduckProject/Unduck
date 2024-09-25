using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // 스폰할 오브젝트 배열
    public int numberOfObjects = 6; // 생성할 오브젝트 수
    private Collider wallCollider; // 벽의 Collider를 참조
    private Collider floorCollider; // 바닥의 Collider를 참조

    void Start()
    {
        // 바닥의 Collider 찾기
        floorCollider = GetComponent<Collider>();

        // 부모의 부모의 부모에서 벽의 Collider 찾기
        FindWallCollider();

        if (wallCollider == null)
        {
            Debug.LogWarning("벽에 Collider가 없습니다.");
            return;
        }

        // 벽의 Bounds 디버깅
        Debug.Log($"Wall Collider Bounds: {wallCollider.bounds}");

        SpawnObjects();
    }

    void FindWallCollider()
    {
        // 부모의 부모의 부모 오브젝트에서 벽의 Collider를 찾기
        Transform grandgrandparent = transform.parent?.parent?.parent;
        if (grandgrandparent != null)
        {
            // "WALL_FACE"로 시작하는 자식 오브젝트 찾기
            foreach (Transform child in grandgrandparent)
            {
                if (child.name.StartsWith("WALL_FACE"))
                {
                    // "NewWall(PrefabSpawner Clone)/Cube" 경로에서 Collider 찾기
                    Transform wallTransform = child.Find("NewWall(PrefabSpawner Clone)/Cube");
                    if (wallTransform != null)
                    {
                        wallCollider = wallTransform.GetComponent<Collider>();
                        break; // Collider를 찾았으면 루프 종료
                    }
                }
            }
        }
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Vector3 randomPosition = GetRandomPosition(randomObject);
            if (randomPosition != Vector3.zero) // 유효한 위치가 반환된 경우에만 생성
            {
                Instantiate(randomObject, randomPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning($"유효한 위치를 찾지 못했습니다.");
            }
        }
    }

    Vector3 GetRandomPosition(GameObject obj)
    {
        Renderer objRenderer = obj.GetComponentInChildren<Renderer>();
        if (objRenderer == null)
        {
            Debug.LogWarning($"'{obj.name}'에는 Renderer가 없습니다. 기본 위치를 사용합니다.");
            return Vector3.zero; // 기본 위치 반환
        }

        // 오브젝트의 크기 가져오기
        Bounds bounds = objRenderer.bounds;
        Vector3 size = bounds.size;

        Vector3 randomPosition;
        int attempts = 0;
        const int maxAttempts = 1000; // 최대 시도 횟수 설정

        do
        {
            // 벽의 Collider 안쪽에서 랜덤 위치 생성
            float randomX = Random.Range(wallCollider.bounds.min.x + size.x / 2, wallCollider.bounds.max.x - size.x / 2);
            float randomZ = Random.Range(wallCollider.bounds.min.z + size.z / 2, wallCollider.bounds.max.z - size.z / 2);
            float randomY = transform.position.y + 0.2f; // 바닥 위에 위치

            randomPosition = new Vector3(randomX, randomY, randomZ);

            // 디버깅 로그 추가
            Debug.Log($"시도 중인 위치: {randomPosition}");

            attempts++;

            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("무한 루프를 방지하기 위해 최대 시도 횟수를 초과했습니다.");
                return Vector3.zero; // 기본 위치 반환
            }

        } while (!IsPositionValid(randomPosition, size));

        return randomPosition;
    }

    bool IsPositionValid(Vector3 position, Vector3 size)
    {
        // 벽의 Collider 안쪽에 있는지 확인
        bool isValid = wallCollider.bounds.Contains(position + size / 2) && wallCollider.bounds.Contains(position - size / 2);

        // 유효성 검사 로그 추가
        if (!isValid)
        {
            Debug.Log($"위치가 유효하지 않음: {position}");
        }

        return isValid;
    }
}
