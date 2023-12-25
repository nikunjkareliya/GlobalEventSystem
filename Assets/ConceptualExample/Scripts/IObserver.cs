using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConceptualExample
{
    public interface IObserver
    {
        void UpdateObserver(ISubject subject);
    }
}