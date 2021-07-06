using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicUI = default;
    [SerializeField]
    Button musicBtn = default;
    bool musicOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void HighScore()
    {     
        SceneManager.LoadScene("HighScore");
    }

    public void Music()
    {
        if(musicOn)
        {
            musicOn = false;
            musicBtn.image.sprite = musicUI[1];
        }else
        {
            musicOn = true;
            musicBtn.image.sprite = musicUI[0];
        }
    }
}
