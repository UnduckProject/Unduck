using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{

    public Slider progressbar;
    public TMP_Text loadtext;
    public GameObject pressA;
    private Coroutine loadingTextCoroutine;


    private void Start()
    {
        StartLoading(GameData.LoadSceneName);
    }

    public void StartLoading(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        loadingTextCoroutine = StartCoroutine(LoadingTextAnimation());

        while (!operation.isDone)
        {
            yield return null;
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if (progressbar.value >= 1f)
            {
                if (loadingTextCoroutine != null)
                {
                    StopCoroutine(loadingTextCoroutine);
                    loadingTextCoroutine = null;
                }

                loadtext.gameObject.SetActive(false);
                pressA.SetActive(true);
            }

            if (OVRInput.GetDown(OVRInput.Button.One) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }

    IEnumerator LoadingTextAnimation()
    {
        while (true)
        {
            loadtext.text = "Loading.";
            yield return new WaitForSeconds(0.5f);
            loadtext.text = "Loading..";
            yield return new WaitForSeconds(0.5f);
            loadtext.text = "Loading...";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
