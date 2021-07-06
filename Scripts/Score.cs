using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int topScore;
    bool getScore = true;
    [SerializeField]
    Text scoreTxt = default;
    [SerializeField]
    Text endGameScoreTxt = default;

    // Update is called once per frame
    void Update()
    {
        if(getScore)
        {
            score = (int)(Camera.main.transform.position.y * 7);
            scoreTxt.text = "SCORE : " + score;
        }
    }

    public void gameOver()
    {
        topScore = SaveScore.getHighScore();
        if(score > topScore)
        {
            SaveScore.setHighScore(score);
        }
        //SaveScore.setHighScore(0);
        getScore = false;
        endGameScoreTxt.text = score.ToString();
    }
}
