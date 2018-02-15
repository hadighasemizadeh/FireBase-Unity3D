using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowGenerator : MonoBehaviour {
    public Text email;
    public Text level;
    public Text score;
    public Image ProfileImage;

    public void InitializePlayersData(Player player)
    {
        email.text = player.email;
        level.text = player.level.ToString();
        score.text = player.score.ToString();
    }
}
