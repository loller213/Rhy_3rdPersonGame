using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{

    [SerializeField] private string[] audioNames;

    public void PlayFootstep()
    {

        int n = Random.Range(0, audioNames.Length);

        AudioManager.Instance.SFXplay(audioNames[n]);
    }

}
