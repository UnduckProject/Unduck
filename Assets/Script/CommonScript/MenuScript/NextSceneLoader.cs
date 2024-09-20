using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneLoader : MonoBehaviour
{
    public Button quitButton;
    public void LoadFirstScene()
    {
        if (quitButton.interactable)
        {
            GameData.LoadSceneName="Stage1";
            SceneManager.LoadScene("Loading");
        }
    }
}