using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject settingPanel;

    private void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState state)
    {
        switch(state)
        {
            case GameState.Menu:
                SetMenu(); 
                break;
            case GameState.InGame: 
                SetInGame(); 
                break;
            case GameState.Gameover: 
                SetGameOver(); 
                break;
        }
    }

    private void SetMenu()
    {
        menuUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        settingPanel.SetActive(false);
    }

    private void SetInGame()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    private void SetGameOver()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void OpenSettingsPanel()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingPanel.SetActive(false);  
    }
}
