using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CurrentStageRequirement : MonoBehaviour
{
    private static CurrentStageRequirement _instance;
    public static CurrentStageRequirement Instance => _instance;

    private int levelRequirement;

    public int levelReq;
    public string tagName;

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
        FindNumberOfGameObjects(tagName);
        getLevelRequirement();
    }

    #region FindObjects
    private void FindNumberOfGameObjects(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        levelRequirement = taggedObjects.Length;

        Debug.Log("Number of game objects with tag '" + tagName + "': " + levelRequirement);
    }
    #endregion

    public int getLevelRequirement()
    {
        levelReq = levelRequirement;

        return levelReq;
    }

}
