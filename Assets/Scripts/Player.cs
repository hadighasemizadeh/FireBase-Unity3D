using UnityEngine;
using System;
using System.Collections.Generic;

public class Player {

    public string email;
    public int score;
    public int level;


    public Player(string _email, int _score, int _level)
    {
        email = _email;
        score = _score;
        level = _level;
    }

    public Player(IDictionary <string,object> dictionary)
    {
        email = dictionary["email"].ToString();
        score = Convert.ToInt32(dictionary["score"]);
        level = Convert.ToInt32(dictionary["level"]);
    }
}
