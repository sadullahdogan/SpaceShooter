using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] livesImage;
    public Text mainPanelScoreText;
    void Start()
    {
        SetNumberOfLifeVisual(GameController.gameController.GetNumberOfLifes());
        SetMainPanelScoreText(GameController.gameController.GetScore());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMainPanelScoreText(int aScore)
    {
        mainPanelScoreText.text = "Score : " + aScore;
    }
    public void RestartCurrentScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void SetNumberOfLifeVisual(int numberOfLives)
    {
        int lastIndexNoOfMyLives = numberOfLives - 1;
        for (int i = 0; i < livesImage.Length; i++)
        {
            if (i > lastIndexNoOfMyLives)
            {
                Color noAlphaColor = new Color(1, 1, 1, 0);
                livesImage[i].color = noAlphaColor;
            }
            else
            {
                Color yesAlphaColor = new Color(1, 1, 1, 1);
                livesImage[i].color = yesAlphaColor;
            }
        }
    }
}
