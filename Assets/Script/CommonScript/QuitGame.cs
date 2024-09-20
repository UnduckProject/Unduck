using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    public Button quitButton;

    public void Quit()
    {
        if (quitButton.interactable)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
