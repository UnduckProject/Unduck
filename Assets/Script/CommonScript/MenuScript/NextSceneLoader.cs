using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class NextSceneLoader : MonoBehaviour
{
    public Button quitButton;

    public void LoadFirstScene()
    {
        if (quitButton.interactable)
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        GameData.LoadSceneName = "Stage1";
        SceneManager.LoadScene("Loading");
    }
}
