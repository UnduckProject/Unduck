using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class NextSceneLoader : MonoBehaviour
{
    public Button NextButton;

    public void LoadFirstScene()
    {
        if (NextButton.interactable)
        {
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("firstScene");
    }
}
