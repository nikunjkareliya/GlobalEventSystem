using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConceptualExample
{
    public class ConcreteObserverA : MonoBehaviour, IObserver
    {
        // Observer class dependent upon Subject to Register & Unregister to receive notifications.
        [SerializeField] private Subject _subject;

        private void Awake()
        {
            _subject.Register(this);
        }

        private void OnDestroy()
        { 
            _subject.Unregister(this);
        }

        public void UpdateObserver(ISubject subject)
        {            
            int updatedHealth = (subject as Subject).Health;
            Debug.Log($"ConcreteObserverA -> health is updated: {updatedHealth}");
        }
    }
}