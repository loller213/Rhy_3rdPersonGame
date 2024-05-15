using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public GameObject playerModel;
    public GameObject hairstyleOption1;

    public Transform head;
    public Transform body;
    public Transform leftArm;
    public Transform rightArm;
    public Transform leftLeg;
    public Transform rightLeg;

    public void ApplyHairstyle()
    {
        GameObject hairstyle = Instantiate(hairstyleOption1);

        hairstyle.transform.parent = head;

        hairstyle.transform.localPosition = Vector3.zero;

        hairstyle.transform.localPosition = new Vector3(0f, -0.02f, 0f);
        hairstyle.transform.localRotation = Quaternion.Euler(270f, 0f, 0f);

        Debug.Log("Hairstyle applied");
    }

    public void RemoveAllWornItems()
    {
        foreach (Transform child in head)
        {
            if (IsWornItem(child.gameObject))
            {
                Destroy(child.gameObject);
            }
        }
        Debug.Log("All worn items removed");
    }

    private bool IsWornItem(GameObject gameObject)
    {
        return gameObject.CompareTag("Hairstyle");
    }

    void UpdateHeadSize(float value)
    {
        head.localScale = Vector3.one * value;
    }

    void UpdateBodySize(float value)
    {
        body.localScale = Vector3.one * value;
    }

    void UpdateArmLength(float value)
    {
        leftArm.localScale = new Vector3(1, value, 1);
        rightArm.localScale = new Vector3(1, value, 1);
    }

    void UpdateLegLength(float value)
    {
        leftLeg.localScale = new Vector3(1, value, 1);
        rightLeg.localScale = new Vector3(1, value, 1);
    }
}


