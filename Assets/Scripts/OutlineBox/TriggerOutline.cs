using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOutline : MonoBehaviour
{
    private void Start()
    {
        DisableOutline();
    }

    public void EnableOutline()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Outline");
    }

    public void DisableOutline()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }

}
