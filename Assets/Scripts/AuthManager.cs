using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

using System.Threading.Tasks;

public class AuthManager : MonoBehaviour {

    // Variable to access to current user information
    Firebase.Auth.FirebaseAuth auth;
    // Delegate of AuthCallBacks (to use yeild we chose IEnum)
    public delegate IEnumerator AuthCallBack(Task<Firebase.Auth.FirebaseUser> task, string operation);
    public event AuthCallBack  authCallBackEvent;
	void Awake () {
        auth = FirebaseAuth.DefaultInstance;
	}
	
	// Method to sign up a new user
	public void SignUpNewUser (string _email, string _password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(_email, _password).ContinueWith(task => {
            StartCoroutine(authCallBackEvent(task, "sign_up"));
        });	
	}

    // Method to sign up a new user
    public void SignInUser(string _email, string _password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(_email, _password).ContinueWith(task => {
            StartCoroutine(authCallBackEvent(task, "signin"));
        });
    }
}
