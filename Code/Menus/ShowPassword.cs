using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPassword : MonoBehaviour
{
    public InputField passwordInputField;
    public Toggle showPasswordToggle;

    private void Start()
    {
        
        showPasswordToggle.onValueChanged.AddListener(ShowOrHidePassword);
    }

    private void ShowOrHidePassword(bool show)
    {
        if (show)
        {
            passwordInputField.contentType = InputField.ContentType.Standard;
        }
        else
        {
            passwordInputField.contentType = InputField.ContentType.Password;
        }

        
        passwordInputField.ForceLabelUpdate();
    }
}
