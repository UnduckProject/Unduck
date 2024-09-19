using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGameover : MonoBehaviour
{
    public OVRPlayerController playerController; 

    void Update()
    {
        // 플레이어의 Y 좌표 체크
        if (playerController.transform.position.y < -5f)
        {
            LoadNewScene();
        }
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("GameOver"); // 씬 전환
    }
}
