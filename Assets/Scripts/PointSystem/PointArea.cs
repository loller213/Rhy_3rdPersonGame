using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointArea : MonoBehaviour
{

/*    public UnityEvent addCovered;
    public UnityEvent subCovered;*/


    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BOX"))
        {
            EventManager.ON_AREA_ENTER?.Invoke();
            Debug.Log("Covered Add: " + PointSystem.Instance.GetPointsCovered());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BOX"))
        {
            EventManager.ON_AREA_LEAVE?.Invoke();
            Debug.Log("Covered Sub: " + PointSystem.Instance.getPtsCvrd);
        }
    }

}
