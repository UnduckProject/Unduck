// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class InGameTextViewer : MonoBehaviour
// {
//     [SerializeField]
//     private GameController gameController;
//     [SerializeField]
//     private TextMeshProUGUI textScore;
//     [SerializeField]
//     private TextMeshProUGUI textPlayTime;
//     [SerializeField]
//     private Slider sliderPlayTime;
//     [SerializeField]
//     private TextMeshProUGUI textCombo;

//     private void Update()
//     {
//         textScore.text = "Score" + gameController.Score;

//         textPlayTime.text = gameController.CurrentTime.ToString("F1");
//         sliderPlayTime.value = gameController.CurrentTime / gameController.MaxTime;

//         textCombo.text = "Combo" + gameController.Combo;
//     }
// }

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class InGameTextViewer : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private TextMeshProUGUI textScore;
    [SerializeField]
    private TextMeshProUGUI textPlayTime;
    [SerializeField]
    private Slider sliderPlayTime;
    [SerializeField]
    private TextMeshProUGUI textCombo;

    private void Start()
    {
        StartCoroutine(FindUIElementsCoroutine()); // UI 요소 찾기 코루틴 시작
    }

    private IEnumerator FindUIElementsCoroutine()
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
                        // "Canvas" 아래의 UI 요소들을 찾음
                        Transform textScoreTransform = canvas.Find("TextScore");
                        Transform textComboTransform = canvas.Find("TextCombo");
                        Transform sliderPlayTimeTransform = canvas.Find("SliderPlayTime");
                        Transform textPlayTimeTransform = sliderPlayTimeTransform.Find("TextPlayTime"); // SliderPlayTime 아래의 TextPlayTime 찾기

                        if (textScoreTransform != null)
                        {
                            textScore = textScoreTransform.GetComponent<TextMeshProUGUI>();
                        }
                        else
                        {
                            Debug.LogWarning("TextScore 오브젝트를 찾을 수 없습니다.");
                        }

                        if (textComboTransform != null)
                        {
                            textCombo = textComboTransform.GetComponent<TextMeshProUGUI>();
                        }
                        else
                        {
                            Debug.LogWarning("TextCombo 오브젝트를 찾을 수 없습니다.");
                        }

                        if (sliderPlayTimeTransform != null)
                        {
                            sliderPlayTime = sliderPlayTimeTransform.GetComponent<Slider>();
                        }
                        else
                        {
                            Debug.LogWarning("SliderPlayTime 오브젝트를 찾을 수 없습니다.");
                        }

                        if (textPlayTimeTransform != null)
                        {
                            textPlayTime = textPlayTimeTransform.GetComponent<TextMeshProUGUI>();
                        }
                        else
                        {
                            Debug.LogWarning("TextPlayTime 오브젝트를 찾을 수 없습니다.");
                        }

                        break; // 모든 UI 요소를 찾으면 루프 종료
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
    }

    private void Update()
    {
        textScore.text = "Score: " + gameController.Score;

        textPlayTime.text = gameController.CurrentTime.ToString("F1");
        sliderPlayTime.value = gameController.CurrentTime / gameController.MaxTime;

        textCombo.text = "Combo: " + gameController.Combo;
    }
}
