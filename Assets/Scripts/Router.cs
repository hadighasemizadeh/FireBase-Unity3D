using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase;
using Firebase.Database;

public class Router : MonoBehaviour {

    // Reference to the root of our database
    private static DatabaseReference dbRef = FirebaseDatabase.DefaultInstance.RootReference;

    // Return Players' node
    public static DatabaseReference Players()
    {
        return dbRef.Child("Players");
    }

    // Return Players' node with special ID
    public static DatabaseReference Players(string uid)
    {
        return dbRef.Child("Players").Child(uid); ;
    }
}
