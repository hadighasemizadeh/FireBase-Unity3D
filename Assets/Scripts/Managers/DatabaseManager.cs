using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using Firebase;
using Firebase.Database;
using System;
public class DatabaseManager : Singleton <DatabaseManager>
{
  // Firebase basic rules
  //"rules": {
  //  ".read": "auth != null",
  //  ".write": "auth != null"
  //          }

// Use this for initialization
new void Awake () {
    base.Awake();

    // Set our database URL
    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://fir-tryonunity3d.firebaseio.com/");
    //// Use .P12 file that we placed in Resources to work and test on Editor
    //FirebaseApp.DefaultInstance.SetEditorP12FileName("FirebaseTryOnUnity3D-33580be18342.p12");
    ////FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("SERVICE-ACCOUNT-ID@YOUR-FIREBASE-APP.iam.gserviceaccount.com");
    //FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("firebase-adminsdk-xcr54@fir-tryonunity3d.iam.gserviceaccount.com");
    //FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

    //// Just for test we push some data to database
    //Debug.Log(Router.Players());
    //Router.Players().SetValueAsync("test 00, 01");
}

    public void CreateNewPlayer(Player player, string uid)
    {
        string PlayerJSON = JsonUtility.ToJson(player);
        Router.Players(uid).SetRawJsonValueAsync(PlayerJSON);
    }

    public void getPlayers(Action<List<Player>> actionCoompletion)
    {
        List<Player> tmpPlayerList = new List<Player>();

        Router.Players().GetValueAsync().ContinueWith(task => {

            DataSnapshot players = task.Result;
            foreach (DataSnapshot player in players.Children)
            {
                var playerDict = (IDictionary<string,object>) player.Value;
                Player mPlayer = new Player(playerDict);
                tmpPlayerList.Add(mPlayer);
            }

            actionCoompletion(tmpPlayerList);
        });
    }

    public void isNewPlayerAdd(object sender, ChildChangedEventArgs args)
    {
        if (args.Snapshot.Value == null)
        {
            Debug.Log("Thre is no data to be displayed!! \n");
        } else {
            Debug.Log("New player added. \n");
        }
    }
}
