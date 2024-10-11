using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demo_go : MonoBehaviour
{
    // Start is called before the first frame update
    public void DemoStage()
    {
        GameData.Demo=true;
        if(gameObject.name == "Toggle")
        {
            SceneManager.LoadScene("Demo_Maze");
        }
        else if(gameObject.name == "Toggle (1)")
        {
            SceneManager.LoadScene("Demo_Golem");
        }
        else if(gameObject.name == "Toggle (2)")
        {
            SceneManager.LoadScene("Demo_Boss");
        }
        else if(gameObject.name == "Toggle (3)")
        {
            SceneManager.LoadScene("Demo_MR");
        }
        else if(gameObject.name == "Toggle (4)")
        {
            SceneManager.LoadScene("Demo_Zombie");
        }
        else if(gameObject.name == "Toggle (5)")
        {
            SceneManager.LoadScene("Demo_Wall");
        }
        else if(gameObject.name == "Toggle (6)")
        {
            SceneManager.LoadScene("Demo_Mole");
        }
    }
}
