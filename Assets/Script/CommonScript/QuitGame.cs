using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class QuitGame : MonoBehaviour
{
    public Button quitButton;

    public void Quit()
    {
        if (quitButton.interactable)
        {
            StartCoroutine(QuitDelay());
        }
    }

    private IEnumerator QuitDelay()
    {
        yield return new WaitForSeconds(1f);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
