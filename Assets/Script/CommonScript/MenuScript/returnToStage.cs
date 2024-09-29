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
                GameData.minigameOn=true;
                GameData.returnTo=true;
                GameData.HasTalked1=false;
            }
            else if(GameData.GameProgress==1)
            {
                GameData.HasTalked2=false;
            }
            else if(GameData.GameProgress==3)
            {
                GameData.HasTalked3=false;
            }
            GameData.DuckTransform=GameData.BeforeDuckTransform;
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(stage);
    }
}
