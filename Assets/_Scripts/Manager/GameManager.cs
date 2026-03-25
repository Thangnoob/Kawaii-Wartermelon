using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Action<GameState> OnGameStateChanged;

    [Header(" Settings ")]
    [SerializeField] GameState gameState;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }

    private void Start()
    {
        SetGameState(GameState.Menu);        
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        OnGameStateChanged?.Invoke(gameState);  
    }

    public bool IsInGameState()
    {
        return gameState == GameState.InGame;
    }
}
