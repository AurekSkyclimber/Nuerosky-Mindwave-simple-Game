using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    private int _score;
    private Text score;

    void Awake()
    {
        score = GameObject.Find("Canvas/scoretext").GetComponent<Text>();
        
    }


    public void update_score(int amount)
    {

        _score += amount;

        score.text = "Score: " + _score;

        Debug.Log("Score: " + _score);
    }
}