using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalEventSystem
{
    public enum GameState
    {
        Home,
        Gameplay,
        LevelFailed,
        LevelWon
    }

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int _totalScore;
        public int TotalScore
        {
            get => _totalScore;
            set
            {
                _totalScore = value;
                Events.OnScoreUpdated.Execute(_totalScore);
            }
        }

        [SerializeField] private HomeUI _homeUI;
        [SerializeField] private GameplayUI _gameplayUI;
        [SerializeField] private LevelCompletedUI _levelCompletedUI;
        [SerializeField] private GameState _currentGameState;

        private void Awake() => GameInit();

        private void OnEnable()
        {
            Events.OnGameStateChanged.Register(OnGameStateChanged);
            Events.OnScoreAdded.Register(OnScoreAdded);
        }

        private void OnDisable()
        {
            Events.OnGameStateChanged.Unregister(OnGameStateChanged);
            Events.OnScoreAdded.Unregister(OnScoreAdded);
        }

        public GameState CurrentGameState { get => _currentGameState; set => _currentGameState = value; }

        private void GameInit()
        {
            _totalScore = 0;
            Events.OnGameStateChanged.Execute(GameState.Gameplay);
        }

        private void OnGameStateChanged(GameState gameState)
        {
            _currentGameState = gameState;

            switch (gameState)
            {
                case GameState.Home:
                    _homeUI.Show();
                    _gameplayUI.Hide();
                    _levelCompletedUI.Hide();
                    break;
                case GameState.Gameplay:
                    _homeUI.Hide();
                    _gameplayUI.Show();
                    _levelCompletedUI.Hide();
                    break;
                case GameState.LevelFailed:
                    break;
                case GameState.LevelWon:
                    _homeUI.Hide();
                    _gameplayUI.Hide();
                    _levelCompletedUI.Show();
                    break;
            }
        }

        private void OnScoreAdded(int score)
        {
            TotalScore += score;
        }
    }
}