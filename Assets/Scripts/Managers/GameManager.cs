using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{ 
    Home,
    Gameplay,
    LevelFailed,
    LevelWon
}

public class GameManager : MonoBehaviour
{    
    void Awake() => GameInit();    

    private void OnEnable() => Events.OnGameStateChanged.Register(OnGameStateChanged);

    private void OnDisable() => Events.OnGameStateChanged.Unregister(OnGameStateChanged);

    [SerializeField] GameState _currentGameState;
    public GameState CurrentGameState { get => _currentGameState; set => _currentGameState = value; }

    void GameInit()
    {
        Events.OnGameStateChanged.Execute(GameState.Gameplay);
    }

    void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Home:
                break;
            case GameState.Gameplay:
                break;
            case GameState.LevelFailed:
                break;
            case GameState.LevelWon:
                break;
        }
    }
}
