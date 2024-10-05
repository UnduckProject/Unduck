// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameController : MonoBehaviour
// {
//     [SerializeField]
//     private CountDown countDown;
//     [SerializeField]
//     private MoleSpawner moleSpawner;
//     private int score;
//     private int combo;
//     private float currentTime;

//     public int Score
//     {
//         set
//         {
//             score = Mathf.Max(0, value);
//             if (score >= 2000) // 2000�� �̻��� ��
//             {
//                 GameOver(); // ���� ����
//             }
//         }
//         get => score;
//     }

//     public int Combo
//     {
//         //set => combo = Mathf.Max(0, value);
//         set
//         {
//             combo = Mathf.Max(0, value);
//             if (combo <= 70)
//             {
//                 moleSpawner.MaxSpawnMole = 1 + (combo + 10) / 20;
//             }

//             if (combo > MaxCombo)
//             {
//                 MaxCombo = combo;
//             }
//         }
//         get => combo;
//     }

//     public int MaxCombo { private set; get; }

//     public int NormalMoleHitCount { set; get; }
//     public int RedMoleHitCount { set; get; }
//     public int BlueMoleHitCount { set; get; }

//     [field: SerializeField]
//     public float MaxTime { private set; get; }
//     // public float CurrentTime { private set; get; }
//     public float CurrentTime
//     {
//         set => currentTime = Mathf.Clamp(value, 0, MaxTime);
//         get => currentTime;
//     }

//     private void Start()
//     {
//         countDown.StartCountDown(GameStart);
//     }

//     private void GameStart()
//     {
//         moleSpawner.Setup();

//         StartCoroutine("OnTimeCount");
//     }

//     private IEnumerator OnTimeCount()
//     {
//         CurrentTime = MaxTime;

//         while (CurrentTime > 0)
//         {
//             CurrentTime -= Time.deltaTime;

//             yield return null;
//         }

//         GameOver();
//     }

//     private void GameOver()
//     {
//         PlayerPrefs.SetInt("CurrentScore", Score);
//         PlayerPrefs.SetInt("CurrentMaxCombo", MaxCombo);
//         PlayerPrefs.SetInt("CurrentNormalMoleHitCount", NormalMoleHitCount);
//         PlayerPrefs.SetInt("CurrentRedMoleHitCount", RedMoleHitCount);
//         PlayerPrefs.SetInt("CurrentBlueMoleHitCount", BlueMoleHitCount);

//         SceneManager.LoadScene("GameOver");
//     }
// }
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private CountDown countDown;
    [SerializeField]
    private MoleSpawner moleSpawner;
    private int score;
    private int combo;
    private float currentTime;

    public int Score
    {
        set
        {
            score = Mathf.Max(0, value);
            if (score >= 2000) // 2000점 이상일 때
            {
                SceneManager.LoadScene("Stage2"); // 게임 오버
            }
        }
        get => score;
    }

    public int Combo
    {
        set
        {
            combo = Mathf.Max(0, value);
            if (combo <= 70)
            {
                moleSpawner.MaxSpawnMole = 1 + (combo + 10) / 20;
            }

            if (combo > MaxCombo)
            {
                MaxCombo = combo;
            }
        }
        get => combo;
    }

    public int MaxCombo { private set; get; }

    public int NormalMoleHitCount { set; get; }
    public int RedMoleHitCount { set; get; }
    public int BlueMoleHitCount { set; get; }

    [field: SerializeField]
    public float MaxTime { private set; get; }
    
    public float CurrentTime
    {
        set => currentTime = Mathf.Clamp(value, 0, MaxTime);
        get => currentTime;
    }

    private void Start()
    {
        StartCoroutine(FindCountDownCoroutine()); // CountDown 찾기 코루틴 시작
    }

    private IEnumerator FindCountDownCoroutine()
    {
        // Game(clone) 오브젝트가 생성될 때까지 대기
        while (true)
        {
            // "SpawnGame" 오브젝트를 찾음
            GameObject spawnGameObject = GameObject.Find("SpawnGame");
            if (spawnGameObject != null)
            {
                // "Game(Clone)" 오브젝트를 찾음
                Transform gameTransform = spawnGameObject.transform.Find("Game(Clone)");
                if (gameTransform != null)
                {
                    Transform canvas = gameTransform.Find("Canvas");
                    if (canvas != null)
                    {
                        // "Canvas" 아래의 "TextCountDown" 오브젝트를 찾아 CountDown 컴포넌트를 가져옴
                        Transform countDownTransform = canvas.Find("TextCountDown");
                        if (countDownTransform != null)
                        {
                            countDown = countDownTransform.GetComponent<CountDown>();
                            break; // 찾으면 루프 종료
                        }
                        else
                        {
                            Debug.LogWarning("TextCountDown 오브젝트를 찾을 수 없습니다.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Canvas 오브젝트를 찾을 수 없습니다.");
                    }
                }
                else
                {
                    Debug.LogWarning("Game(Clone) 오브젝트를 찾을 수 없습니다.");
                }
            }
            else
            {
                Debug.LogWarning("SpawnGame 오브젝트를 찾을 수 없습니다.");
            }
            // 잠시 대기 후 다시 확인
            yield return new WaitForSeconds(0.1f);
        }

        countDown.StartCountDown(GameStart); // CountDown이 준비된 후 게임 시작
    }

    private void GameStart()
    {
        moleSpawner.Setup();
        StartCoroutine(OnTimeCount());
    }

    private IEnumerator OnTimeCount()
    {
        CurrentTime = MaxTime;

        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            yield return null;
        }

        GameOver();
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("CurrentScore", Score);
        PlayerPrefs.SetInt("CurrentMaxCombo", MaxCombo);
        PlayerPrefs.SetInt("CurrentNormalMoleHitCount", NormalMoleHitCount);
        PlayerPrefs.SetInt("CurrentRedMoleHitCount", RedMoleHitCount);
        PlayerPrefs.SetInt("CurrentBlueMoleHitCount", BlueMoleHitCount);

        SceneManager.LoadScene("GameOver");
    }
}
