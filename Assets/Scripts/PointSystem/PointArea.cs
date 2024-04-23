using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class PointArea : MonoBehaviour
{
    private BoxCollider pointCollider;

    private void Start()
    {
        pointCollider = GetComponent<BoxCollider>();
        pointCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BOX"))
        {
            EventManager.ON_AREA_ENTER?.Invoke();
            Debug.Log("(On add) Covered: " + PointSystem.Instance.GetPointsCovered());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BOX"))
        {
            EventManager.ON_AREA_LEAVE?.Invoke();
            Debug.Log("(On sub) Covered: " + PointSystem.Instance.GetPointsCovered());
        }
    }

}
