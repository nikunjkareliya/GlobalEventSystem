using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManagerDemo
{
    /// <summary>
    /// Class responsible for firing/triggering an event
    /// </summary>
    public class Subject : MonoBehaviour
    {
        private int _score = 0;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _score += 10;
                EventManager<float>.Execute(EventKeys.SCORE_UPDATED, _score);                
            }
        }
    }

}