using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManagerDemo
{
    public class Observer : MonoBehaviour
    {
        private void Start()
        {
            EventManager<float>.Register(EventKeys.SCORE_UPDATED, HandleScoreUpdated);
        }

        private void OnDestroy()
        {
            EventManager<float>.Unregister(EventKeys.SCORE_UPDATED, HandleScoreUpdated);            
        }

        private void HandleScoreUpdated(float score)
        {
            Debug.Log($"Score is updated: {score}");
        }
    }
}