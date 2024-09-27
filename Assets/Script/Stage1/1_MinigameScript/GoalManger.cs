using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; 

public class GoalManager : MonoBehaviour
{
    public static GoalManager Instance;

    public int totalGoals = 0; 
    public int remainingGoals = 0; 

    public TMP_Text goalCountText; 
    public AudioSource audioSource;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterGoal()
    {
        totalGoals++;
        remainingGoals++;
        UpdateGoalCountText();
    }

    public void GoalDestroyed()
    {
        remainingGoals--;
        UpdateGoalCountText();

        if (remainingGoals <= 0)
        {
            GameData.Win=true;
            GameData.GameProgress=1;
            StartCoroutine(VictoryDelay());
        }
    }

    void UpdateGoalCountText()
    {
        if (goalCountText != null)
        {
            goalCountText.text = $"Goals: {remainingGoals}/{totalGoals}";
        }
    }

    private IEnumerator VictoryDelay()
    {
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Stage1");

    }


}
