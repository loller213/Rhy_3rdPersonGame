using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CurrentStageRequirement : MonoBehaviour
{
    private static CurrentStageRequirement _instance;
    public static CurrentStageRequirement Instance => _instance;

    //[SerializeField] private string sceneNames;
    private int levelRequirement;

    public int levelReq;
    public string sceneName;
    private Scene scene;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetLevelReq();
        getLevelRequirement();
    }

    #region SetLevelRequirement
    private void SetLevelReq()
    {
        //GetScene
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name.ToString();

        //CheckScene
        switch (scene.name.ToString()) {

            case "Level1":
            case "SampleScene":
                levelRequirement = 1;
                break;

            case "Level2":
                levelRequirement = 2;
                break;

            case "Level3":
                levelRequirement = 2;
                break;

            case "Level4":
                levelRequirement = 3;
                break;

            case "Level5":
                levelRequirement = 4;
                break;

            case "Level6":
                levelRequirement = 4;
                break;

            case "Level7":
                levelRequirement = 2;
                break;

            case "Level8":
                levelRequirement = 3;
                break;

            case "Level9":
                levelRequirement = 1;
                break;

            case "Level10":
                levelRequirement = 1;
                break;

            case "Level11":
                levelRequirement = 1;
                break;

            case "Level12":
                levelRequirement = 1;
                break;

            case "Level13":
                levelRequirement = 1;
                break;

            case "Level14":
                levelRequirement = 1;
                break;

            case "Level15":
                levelRequirement = 1;
                break;
        }
    }
    #endregion

    public int getLevelRequirement()
    {
        levelReq = levelRequirement;

        return levelReq;
    }

}
