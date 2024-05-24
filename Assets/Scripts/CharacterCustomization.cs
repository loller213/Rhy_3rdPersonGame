using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    public GameObject playerModel;
    public GameObject hairstyleOption1;
    public GameObject hairstyleOption2;

    public GameObject ToolOption1;

    public Transform head;
    public Transform body;
    public Transform leftArm;
    public Transform rightArm;
    public Transform leftLeg;
    public Transform rightLeg;

    public void ApplyHairstyle1()
    {
        if (LevelCounter.Instance.GetPlayerLevel() >= 1)
        {
            ChangeHairstyle();

            if (hairstyleOption1 == null || head == null)
            {
                Debug.LogError("HairstyleOption1 or head is not assigned in the inspector.");
                return;
            }

            GameObject hairstyle = Instantiate(hairstyleOption1);

            hairstyle.transform.SetParent(head);
            hairstyle.transform.localPosition = new Vector3(0f, -0.004f, 0f);
            hairstyle.transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
            hairstyle.tag = "Hairstyle";

            Debug.Log("Hairstyle1 applied");
        }
        else
        {
            Debug.Log("Level 1 required to apply this hairstyle");
        }
    }

    public void ApplyHairstyle2()
    {
        if (LevelCounter.Instance.GetPlayerLevel() >= 2)
        {
            ChangeHairstyle();

            if (hairstyleOption2 == null || head == null)
            {
                Debug.LogError("HairstyleOption2 or head is not assigned in the inspector.");
                return;
            }

            GameObject hairstyle = Instantiate(hairstyleOption2);

            hairstyle.transform.SetParent(head);
            hairstyle.transform.localPosition = new Vector3(0f, -0.002f, 0.004f);
            hairstyle.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            hairstyle.tag = "Hairstyle";

            Debug.Log("Hairstyle2 applied");
        }
        else
        {
            Debug.Log("Level 2 required to apply this hairstyle");
        }
    }

    public void ApplyTools1()
    {
        if (LevelCounter.Instance.GetPlayerLevel() >= 2)
        {
            
            if (ToolOption1 == null || head == null)
            {
                Debug.LogError("ApplyTools1 or rightArm is not assigned in the inspector.");
                return;
            }

            GameObject Rarm = Instantiate(ToolOption1);

            Rarm.transform.SetParent(rightArm);
            Rarm.transform.localPosition = new Vector3(0f, 0.0025f, -0.0029f);
            Rarm.transform.localRotation = Quaternion.Euler(0f, 60f, 270f);
            Rarm.tag = "Tools";

            Debug.Log("ApplyTools1 applied");
        }
        else
        {
            Debug.Log("Level 3 required to apply this hairstyle");
        }
    }

    public void RemoveCurrentWornItems()
    {
        foreach (Transform child in head)
        {
            if (IsWornItem(child.gameObject))
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in rightArm)
        {
            if (IsWornItem(child.gameObject))
            {
                Destroy(child.gameObject);
            }
        }

        Debug.Log("Current worn items removed");
    }

    public void ChangeHairstyle()
    {
        foreach (Transform child in head)
        {
            if (IsWornItem(child.gameObject))
            {
                Destroy(child.gameObject);
            }
        }

        Debug.Log("Current worn items changed");
    }

    public void ChangeToolsR()
    {
        foreach (Transform child in rightArm)
        {
            if (IsWornItem(child.gameObject))
            {
                Destroy(child.gameObject);
            }
        }

        Debug.Log("Current worn tools changed");
    }

    private bool IsWornItem(GameObject gameObject)
    {
        return gameObject.CompareTag("Hairstyle") || gameObject.CompareTag("Tools");
    }

    private bool NewHairstyle(GameObject gameObject)
    {
        return gameObject.CompareTag("Hairstyle");
    }

    private bool NewTool(GameObject gameObject)
    {
        return gameObject.CompareTag("Tools");
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

