using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class FormManager : MonoBehaviour {

    public InputField emailInputField;
    public InputField PasswordInputField;

    public Button signUpBtn;
    public Button signInBtn;

    public Text connectionState;

    public AuthManager authManager;

    private void Awake()
    {
        ToggleButtonState(false);
        // Subscribe auth delegates
        authManager.authCallBackEvent += AuthCallBackHandller;
    }

    // Clean subscribed methods
    private void OnDestroy()
    {
        authManager.authCallBackEvent -= AuthCallBackHandller;
    }

    public void isValidEmail()
    {
        string email = emailInputField.text;
        var checkPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"  +
                           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";


        bool state = (email != "") && (Regex.IsMatch(email, checkPattern));
        ToggleButtonState(state);

    }

    public void OnSignIn()
    {
        authManager.SignInUser(emailInputField.text, PasswordInputField.text);
        Debug.Log("Signed In");
    }

    public void OnSignUp()
    {
        authManager.SignUpNewUser(emailInputField.text, PasswordInputField.text);
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

    IEnumerator AuthCallBackHandller(Task<Firebase.Auth.FirebaseUser> task, string _operation)
    {
        if (task.IsCanceled || task.IsFaulted)
        {
            DisplayMessage("Error: " + task.Exception);
        } else if (task.IsCompleted)
        {
            Firebase.Auth.FirebaseUser newPlayer = task.Result;
            DisplayMessage(string.Format("user with {0} address signed up successfully.", newPlayer.Email));

            yield return new WaitForSeconds(2F);
            SceneManager.LoadScene("PlayerList");
        }
    }
}
