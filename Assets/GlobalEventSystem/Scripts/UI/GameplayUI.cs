using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

namespace GlobalEventSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;
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