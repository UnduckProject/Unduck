using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class returnToStage : MonoBehaviour
{
    public Button NextButton;
    public string stage;

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
        SceneManager.LoadScene(stage);
    }
}
