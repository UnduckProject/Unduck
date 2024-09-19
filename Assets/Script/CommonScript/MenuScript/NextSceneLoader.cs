using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public void LoadFirstScene()
    {
        GameData.LoadSceneName="Stage1";
        SceneManager.LoadScene("Loading");
    }
}