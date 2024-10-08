/*
 * Deprecated event manager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EventManagerDemo
{
    public static class EventManagerDeprecated
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

        public static void Register(string eventType, Action<T> eventHandler)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType] = eventHandler;
            }
            else
            {
                _eventDictionary.Add(eventType, eventHandler);
            }
        }

        public static void Unregister(string eventType, Action<T> eventHandler)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType] -= eventHandler;
            }
        }

        public static void Execute(string eventType, T eventArgs)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType]?.Invoke(eventArgs);
            }
        }
    }

    public static class EventManager<T1, T2>
    {
        private static Dictionary<string, Action<T1, T2>> _eventDictionary = new Dictionary<string, Action<T1, T2>>();

        public static void Register(string eventType, Action<T1, T2> eventHandler)
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

        public static void Unregister(string eventType, Action<T1, T2> eventHandler)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType] -= eventHandler;
            }
        }

        public static void Execute(string eventType, T1 eventArgs1, T2 eventArgs2)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType]?.Invoke(eventArgs1, eventArgs2);
            }
        }
    }
}
