using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplayer : MonoBehaviour
{
    public Text textScore;

    private int score;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ball")
        {
            textScore.text = (++score).ToString();
        }
    }
}
