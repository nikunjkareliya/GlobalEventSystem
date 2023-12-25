using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConceptualExample
{
    public class Subject : MonoBehaviour, ISubject
    {
        [SerializeField] private int _health = 0;
        public int Health => _health;

        private List<IObserver> _observers = new List<IObserver>();

        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {            
            _observers.Remove(observer);
        }

        public void Notify()
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].UpdateObserver(this);
            }
        }

        private void Start()
        {
            _health = 100;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage();
                Notify();
            }
        }

        private void TakeDamage()
        {
            if (_health > 0) 
            {
                _health--;
            }
        }
    }
}