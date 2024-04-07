using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private float score;
    private float scoreIncrement = 5;
    private float nextIncrementTime;

    void Start()
    {
        nextIncrementTime = Time.time + 30; // Change this line
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemySpawnManager.instance != null && !PlayerManager.isGameOver)
        {
            scoreText.text = ((int)score).ToString();
        }

        if (Time.time > nextIncrementTime)
        {
            scoreIncrement += 5;
            nextIncrementTime = Time.time + 30; // Change this line
        }
    }

    public void IncreaseScore()
    {
        score += scoreIncrement;
    }
}