using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;


public class PlayerBoardManager : MonoBehaviour
{
    public Firebase.Auth.FirebaseAuth auth;
    public List<Player> playersList;
    public GameObject rowPrefab;
    public Transform scrollContent;

    public GameObject profilePanel;

    private void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        playersList = new List<Player>();

        DatabaseManager.Instance.getPlayers(result =>
        {
            // Set our playersList with result of our action
            playersList = result;

            //Initialize Rows
            InitializeRow();
        });

        // Set current profile with current signedin player
        profilePanel.GetComponent<PlayerProfile>().setPlayerProfile(auth.CurrentUser);

        //// Whenever I new player signed up all players receive a note.
        //Router.Players().ChildAdded += DatabaseManager.Instance.isNewPlayerAdd;

        //// Sort by best score
        //Router.Players().OrderByChild("score").LimitToLast(1).ValueChanged += HandleValueChanged;
    }

    void InitializeRow()
    {
        for (int i = 0; i < playersList.Count; i++)
            CreateRow(playersList[i]);

    }

    void CreateRow(Player player)
    {
        GameObject newRow = Instantiate(rowPrefab) as GameObject;
        newRow.transform.SetParent(scrollContent,false);
        newRow.GetComponent<RowGenerator>().InitializePlayersData(player);
    }

    //void HandleValueChanged(object sender, ValueChangedEventArgs args)
    //{
    //    if (args.DatabaseError != null)
    //    {
    //        Debug.LogError(args.DatabaseError.Message);
    //        return;
    //    }
    //}
}
