using UnityEngine;

public class RandomPositionPlacer : MonoBehaviour
{
    public GameObject[] objectsToPlace; // 배치할 오브젝트 배열
    public Collider groundCollider; // 바닥 콜라이더
    public Collider wallCollider; // 벽 콜라이더
    public int numberOfObjectsToPlace = 6; // 배치할 오브젝트 수
    public int maxAttempts = 10; // 최대 시도 횟수

    void Start()
    {
        for (int i = 0; i < numberOfObjectsToPlace; i++)
        {
            PlaceObjectRandomly();
        }
    }

    void PlaceObjectRandomly()
    {
        if (groundCollider == null || wallCollider == null || objectsToPlace.Length == 0)
        {
            Debug.LogError("필수 요소가 설정되지 않았습니다.");
            return;
        }

        // 바닥 콜라이더의 경계값을 얻기
        Bounds groundBounds = groundCollider.bounds;

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            // 랜덤한 위치 생성
            Vector3 randomPosition = new Vector3(
                Random.Range(groundBounds.min.x, groundBounds.max.x),
                groundBounds.min.y + 0.5f,
                Random.Range(groundBounds.min.z, groundBounds.max.z)
            );

            // 벽 콜라이더에 포함되는지 확인
            if (wallCollider.bounds.Contains(randomPosition))
            {
                // 랜덤하게 오브젝트 선택
                GameObject randomObject = objectsToPlace[Random.Range(0, objectsToPlace.Length)];
                // 오브젝트를 생성
                Instantiate(randomObject, randomPosition, Quaternion.identity);
                return; // 성공적으로 배치된 경우 종료
            }
        }

        Debug.Log("최대 시도 횟수를 초과했습니다. 오브젝트를 배치할 수 없습니다.");
    }
}
