using UnityEngine;
public class FollowWrist : MonoBehaviour
{
    public Transform rightController; // 오른쪽 컨트롤러의 Transform
    public Vector3 offset = new Vector3(0, -0.1f, 0); // 손목 근처로 위치를 조정하기 위한 오프셋

    void Update()
    {
        if (rightController != null)
        {
            // 텍스트를 컨트롤러 위치에 따라가도록 설정, 오프셋을 더해 손목 위치에 배치
            transform.position = rightController.position + rightController.rotation * offset;
            transform.rotation = rightController.rotation;
        }
    }
}
