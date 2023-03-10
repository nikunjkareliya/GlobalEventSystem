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
    [SerializeField] int _totalScore;
    public int TotalScore { get => _totalScore;
        set {
            _totalScore = value;
            Events.OnScoreUpdated.Execute(_totalScore);
        } 
    }

    void Awake() => GameInit();

    private void OnEnable() { 
        Events.OnGameStateChanged.Register(OnGameStateChanged);
        Events.OnScoreAdded.Register(OnScoreAdded);
    }

    private void OnDisable() {
        Events.OnGameStateChanged.Unregister(OnGameStateChanged);
        Events.OnScoreAdded.Unregister(OnScoreAdded);
    } 

    [SerializeField] GameState _currentGameState;
    public GameState CurrentGameState { get => _currentGameState; set => _currentGameState = value; }

    void GameInit()
    {
        _totalScore = 0;
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

    void OnScoreAdded(int score)
    {
        TotalScore += score;
    }
}
