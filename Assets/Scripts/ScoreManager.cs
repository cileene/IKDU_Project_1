using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ShowNewScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ShowNewScore();
    }

    public void RemoveScore(int scoreToRemove)
    {
        score -= scoreToRemove;
        ShowNewScore();
    }

    void ShowNewScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
