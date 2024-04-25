using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance;

    [Header("Loading Screen")]
    public GameObject LoadingScreen;
    public Slider progressBar;
    public TextMeshProUGUI progressCount;

    private void Awake()
    {
        Instance = this;
    }

    //public void SetActive(GameObject panel)
    //{
    //    if (panel.activeSelf)
    //    {
    //        panel.SetActive(false);
    //    }else if (!panel.activeSelf)
    //    {
    //        panel.SetActive(true);
    //    }
    //}

    public void LoadSceneSingle(string sceneName)
    {
        //SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        StartCoroutine(LoadSceneAsyncSingle(sceneName));
    }

    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadSceneAsync(sceneName));

    }


    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;
            progressCount.text = progress * 100 + "%";

            yield return null;
        }

    }

    IEnumerator LoadSceneAsyncSingle(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;
            progressCount.text = progress * 100 + "%";

            yield return null;
        }

    }

    public void QuitGameMainMenu()
    {
        Application.Quit();
    }

}
