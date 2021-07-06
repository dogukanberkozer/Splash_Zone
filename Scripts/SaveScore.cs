using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveScore
{
    public static string score = "score";

    public static void setHighScore(int score)
    {
        PlayerPrefs.SetInt(SaveScore.score, score);
    }
    public static int getHighScore()
    {
        return PlayerPrefs.GetInt(SaveScore.score);
    }
}
