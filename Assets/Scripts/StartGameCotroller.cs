using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameCotroller : MonoBehaviour
{
    public Button StartGameBtn;
    public Button ExitGameBtn;
    // Start is called before the first frame update
    void Start()
    {
        StartGameBtn.onClick.AddListener(StartGame);
        ExitGameBtn.onClick.AddListener(ExitGame);
        
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartGame() {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene+1);
    }
}
