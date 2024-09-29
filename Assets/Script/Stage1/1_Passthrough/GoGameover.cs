using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGameover : MonoBehaviour
{
    public Transform camera; 

    void Update()
    {
        if (camera.transform.position.y < -30f)
        {
            LoadNewScene();
        }
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
