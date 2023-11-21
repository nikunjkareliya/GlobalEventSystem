using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

namespace GlobalEventSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HomeUI : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;

        private void Awake()
        {

        }

        private void OnDestroy()
        {

        }

        public void ButtonPlay(LevelData levelData)
        {
            Events.OnGameStateChanged.Execute(GameState.Gameplay);
            Events.OnLevelInitialized.Execute(levelData);
        }

        public void Show()
        {
            _canvasGroup.DOFade(1f, 0.5f).OnComplete(() =>
            {
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            });
        }

        public void Hide()
        {
            _canvasGroup.DOFade(0f, 0.5f).OnComplete(() =>
            {
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            });
        }
    }
}