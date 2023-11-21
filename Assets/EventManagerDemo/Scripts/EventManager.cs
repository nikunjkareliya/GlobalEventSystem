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

    public static class EventManager<TEventArgs>
    {
        private static Dictionary<string, Action<TEventArgs>> _eventDictionary = new Dictionary<string, Action<TEventArgs>>();

        public static void Register(string eventType, Action<TEventArgs> eventHandler)
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

        public static void Unregister(string eventType, Action<TEventArgs> eventHandler)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType] -= eventHandler;
            }
        }

        public static void Execute(string eventType, TEventArgs eventArgs)
        {
            if (_eventDictionary.ContainsKey(eventType))
            { 
                _eventDictionary[eventType]?.Invoke(eventArgs);
            }
        }
    }

    public static class EventManager<TEventArgs1, TEventArgs2>
    {
        private static Dictionary<string, Action<TEventArgs1, TEventArgs2>> _eventDictionary = new Dictionary<string, Action<TEventArgs1, TEventArgs2>>();

        public static void Register(string eventType, Action<TEventArgs1, TEventArgs2> eventHandler)
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

        public static void Unregister(string eventType, Action<TEventArgs1, TEventArgs2> eventHandler)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType] -= eventHandler;
            }
        }

        public static void Execute(string eventType, TEventArgs1 eventArgs1, TEventArgs2 eventArgs2)
        {
            if (_eventDictionary.ContainsKey(eventType))
            {
                _eventDictionary[eventType]?.Invoke(eventArgs1, eventArgs2);
            }
        }
    }
}