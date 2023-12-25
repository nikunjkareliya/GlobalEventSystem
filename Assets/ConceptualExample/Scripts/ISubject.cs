using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConceptualExample
{
    public interface ISubject
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify();
    }
}