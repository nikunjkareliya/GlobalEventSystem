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
            EventManager.Register<float>(EventKeys.SCORE_UPDATED, HandleScoreUpdated);            
        }

        private void OnDestroy()
        {
            EventManager.Unregister<float>(EventKeys.SCORE_UPDATED, HandleScoreUpdated);            
        }

        private void HandleScoreUpdated(float score)
        {
            Debug.Log($"Score is updated: {score}");
        }
    }
}