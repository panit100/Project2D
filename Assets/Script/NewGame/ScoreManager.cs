using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score : " + score;
    }

    public void AddScore(){
        score++;
    }
}
