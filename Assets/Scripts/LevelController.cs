using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Transform DeathPanel;
    public Button Replay;
    public Button AnaMenu;
    public Button Exit;
    // Start is called before the first frame update
    void Start()
    {
        Replay.onClick.AddListener(YenidenOyna);
        AnaMenu.onClick.AddListener(MainMenu);
        Exit.onClick.AddListener(Cikis);
    }

    private void Cikis()
    {
        Application.Quit();
    }

    private void MainMenu()
    {
        DeathPanel.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void YenidenOyna()
    {
        GameController.gameController.SetNumberOfLifes(3);
        GameController.gameController.RestartScene();

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameController.GetGameState()) {
            DeathPanel.gameObject.SetActive(true);
        }   
    }
}
