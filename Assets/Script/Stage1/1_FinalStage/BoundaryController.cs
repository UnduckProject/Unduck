using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the boundary!");

            // 새로운 위치 설정 (Boundary의 위치로 이동)
            Vector3 newPosition = transform.position;

            // CharacterController가 있는지 확인
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                // CharacterController 비활성화
                controller.enabled = false;

                // 위치 변경
                other.transform.position = newPosition;

                // CharacterController 다시 활성화
                controller.enabled = true;
            }
            else
            {
                // CharacterController가 없을 경우 직접 위치 변경
                other.transform.position = newPosition;
            }
        }
    }
}
