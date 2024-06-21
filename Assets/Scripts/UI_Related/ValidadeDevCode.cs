using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValidadeDevCode : MonoBehaviour
{

    [SerializeField] private TMP_InputField input;
    [SerializeField] private string code = "NTEKdevscreen";
    [SerializeField] private GameObject devScreen;
    [SerializeField] private TextMeshProUGUI result;

    private void Start()
    {
        devScreen.SetActive(false);
    }

    public void ValidateInput()
    {
        string inputCode = input.text;
        if (inputCode == code)
        {
            devScreen.SetActive(true);
            result.color = Color.green;
            result.text = "Dev Screen Activated";

        }else if (inputCode != code)
        {
            result.color = Color.red;
            result.text = "Wrong Code";
        }
    }

}
