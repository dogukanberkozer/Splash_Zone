using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject jumpButton;
    public GameObject joystick;

    void Start()
    {
        gameOverPanel.SetActive(false);
        UIon();
    }

    void UIon()
    {
        jumpButton.SetActive(true);
        joystick.SetActive(true);
    }

    void UIoff()
    {
        jumpButton.SetActive(false);
        joystick.SetActive(false);
    }

    public void FinishGame()
    {
        gameOverPanel.SetActive(true);
        FindObjectOfType<Score>().gameOver();
        FindObjectOfType<CameraMovement>().finishGame();
        UIoff();
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart(){
        SceneManager.LoadScene("Game");
    }
}
