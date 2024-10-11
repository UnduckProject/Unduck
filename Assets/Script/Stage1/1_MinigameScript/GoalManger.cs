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
    void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        totalGoals = 0; 
        remainingGoals = 0; 
        UpdateGoalCountText();
    }

    void Update()
    {
        if (goalCountText == null)
        {
            goalCountText = GameObject.Find("WristText")?.GetComponent<TMP_Text>();
            audioSource = GameObject.Find("Success")?.GetComponent<AudioSource>();
            if (goalCountText != null)
            {
                UpdateGoalCountText();
                Debug.Log("WristText found and updated.");
            }
            else
            {
                Debug.LogWarning("WristText not found!");
            }
        }
        if(OVRInput.GetDown(OVRInput.Button.Start))
        {
            if(GameData.minigameOn)
                GameData.minigameOn=false;
            else
                GameData.minigameOn=true;
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

        if (remainingGoals <= 0 && !GameData.minigameOn)
        {
            GameData.Win=true;
            GameData.duckwan=false;
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
        if(GameData.Demo){
            SceneManager.LoadScene("NewMenu");
        }
        else{
            SceneManager.LoadScene("Stage1");
        }
    }


}