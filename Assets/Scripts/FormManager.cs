using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class FormManager : MonoBehaviour {

    public InputField emailInputField;
    public InputField PasswordInputField;

    public Button signUpBtn;
    public Button signInBtn;

    public Text connectionState;

    private void Awake()
    {
        ToggleButtonState(false);
    }

    public void isValidEmail()
    {
        string email = emailInputField.text.ToString();
        var checkPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"  +
                           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";


        bool state = (email != "") && (Regex.IsMatch(email, checkPattern));
        ToggleButtonState(state);

    }

    public void OnSignIn()
    {
        Debug.Log("Signed In");
    }

    public void OnSignUp()
    {
        Debug.Log("Signed Up");
    }

    public void OnSignOut()
    {
        Debug.Log("Signed Out");
    }

    // Change buttons interactibilities
    private void ToggleButtonState(bool toggleState)
    {
        signUpBtn.interactable = toggleState;
        signInBtn.interactable = toggleState;
    }

    // Display message on connection state textbox
    private void DisplayMessage(string msg)
    {
        connectionState.text = msg;
    }
}
