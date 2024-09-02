using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EventManagerDemo
{
    public static class EventManager
    {
        private static Dictionary<string, Action> _eventDictionary = new Dictionary<string, Action>();

        public static void Register(string eventType, Action eventHandler)
        {
            if (!_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType] = eventHandler;
            }
            else
            {
                _eventDictionary[eventType] += eventHandler;
            }
        }

        public static void Unregister(string eventType, Action eventHandler)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType] -= eventHandler;
            }
        }

        public static void Execute(string eventType)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType]?.Invoke();
            }
        }
    }

    public static class EventManager<T>
    {
        private static readonly Dictionary<string, Action<T>> _eventDictionary = new Dictionary<string, Action<T>>();

        public static void Register(string incidentId, Action<T> action)
        {
            if (_eventDictionary.ContainsKey(incidentId))
            {
                _eventDictionary[incidentId] = action;
            }
            else
            {
                _eventDictionary.Add(incidentId, action);
            }
        }

        public static void Unregister(string incidentId, Action<T> action)
        {
            if (_eventDictionary.ContainsKey(incidentId))
            {
                _eventDictionary[incidentId] -= action;
            }
        }

        public static void Execute(string incidentId, T args)
        {
            if (_eventDictionary.ContainsKey(incidentId))
            {
                _eventDictionary[incidentId]?.Invoke(args);
            }
        }
    }
}