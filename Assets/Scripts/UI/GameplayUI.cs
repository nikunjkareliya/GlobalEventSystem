using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textScore;

    private void Awake()
    {
        Events.OnScoreUpdated.Register(OnScoreUpdated);
    }
    
    private void OnDestroy()
    {
        Events.OnScoreUpdated.Unregister(OnScoreUpdated);        
    }

    private void OnScoreUpdated(int totalScore)
    {
        _textScore.text = totalScore.ToString();
    }

}
