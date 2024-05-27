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

    private Scene scene;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    public void RestartScene()
    {
        scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        //Open Loading Screen
        LoadingScreen.SetActive(true);

        //Start loading bar
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
