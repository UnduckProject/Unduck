using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Continuebutton : MonoBehaviour
{
    public Button NextButton;
    public GameObject menu;

    public void closeMenu()
    {
        if (NextButton.interactable)
        {
            menu.SetActive(false);
        }
    }

}
