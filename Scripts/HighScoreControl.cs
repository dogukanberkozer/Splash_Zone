using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreControl : MonoBehaviour
{
    public Text myScore;

    // Start is called before the first frame update
    void Start()
    {
        myScore.text = SaveScore.getHighScore().ToString();
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
}
