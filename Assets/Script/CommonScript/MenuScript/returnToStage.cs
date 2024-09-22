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
            if(GameData.GameProgress==0)
            {
                GameData.HasTalked1=false;
            }
            else if(GameData.GameProgress==1)
            {
                GameData.HasTalked2=false;
            }
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(stage);
    }
}
