using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    // Game
    public static readonly GameEvent<GameState> OnGameStateChanged = new GameEvent<GameState>();

    // Input
    public static readonly GameEvent<Vector3> OnMouseButtonClicked = new GameEvent<Vector3>();
    public static readonly GameEvent<Vector3> OnAxisValuesChanged = new GameEvent<Vector3>();
    public static readonly GameEvent<float> OnHorizontalAxis = new GameEvent<float>();
    public static readonly GameEvent<float> OnVerticalAxis = new GameEvent<float>();

    public static readonly GameEvent OnGameOver = new GameEvent();
    public static readonly GameEvent<int> OnScoreAdded = new GameEvent<int>();
    public static readonly GameEvent<int> OnScoreUpdated = new GameEvent<int>();
}