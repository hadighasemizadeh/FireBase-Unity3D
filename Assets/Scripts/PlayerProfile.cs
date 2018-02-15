using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class PlayerProfile : MonoBehaviour {
    public Text  profileEmail;
    public Image profileImage;

	public void setPlayerProfile (Firebase.Auth.FirebaseUser user) {
        profileEmail.text   = user.Email;
        //profileImage.sprite = user....;

    }
}
