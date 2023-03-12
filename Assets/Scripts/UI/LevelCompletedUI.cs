using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class LevelCompletedUI : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    
    private void Awake()
    {
        
    }
    
    private void OnDestroy()
    {
        
    }

    public void ButtonHome()
    {
        Events.OnGameStateChanged.Execute(GameState.Home);
    }

    public void ButtonReplay()
    {
        Events.OnGameStateChanged.Execute(GameState.Gameplay);
    }

    public void Show()
    {
        _canvasGroup.DOFade(1f, 0.5f).OnComplete(() => {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        });
    }

    public void Hide()
    {
        _canvasGroup.DOFade(0f, 0.5f).OnComplete(() => {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        });
    }
}
