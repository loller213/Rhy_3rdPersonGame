using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomLeves : MonoBehaviour
{
    public int levelGen;
    public void LoadRandom()
    {
        levelGen = Random.Range(18, 37);
        SceneManager.LoadScene(levelGen);
    }
}
