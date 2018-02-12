using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class AuthManager : MonoBehaviour {

    // Variable to access to current user information
    Firebase.Auth.FirebaseAuth auth;


	void Awake () {
        auth = FirebaseAuth.DefaultInstance;
	}
	
	// Method to sign up a new user
	public void SignUpNewUser (string _email, string _password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(_email, _password).ContinueWith(task => {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Error: " + task.Exception);
            } else if (task.IsCompleted) {
                Firebase.Auth.FirebaseUser newPlayer = task.Result;
                Debug.Log(string.Format("user with {0} address signed up successfully.", newPlayer.Email));
            }
        });	
	}
}
