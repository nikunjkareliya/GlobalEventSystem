using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalEventSystem
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidBody;
        bool _movementDetected;
        Vector3 _movementVector;

        private void OnEnable()
        {
            Events.OnAxisValuesChanged.Register(OnAxisValuesChanged);
        }

        private void OnDisable()
        {
            Events.OnAxisValuesChanged.Unregister(OnAxisValuesChanged);
        }

        #region HANDLERS
        void OnAxisValuesChanged(Vector3 movementVector)
        {
            _movementVector = movementVector;
            if (movementVector.sqrMagnitude != 0)
            {
                _movementDetected = true;
            }
            else
            {
                _movementDetected = false;
            }

        }
        #endregion

        private void FixedUpdate()
        {
            if (_movementDetected)
            {
                _rigidBody.AddForce(_movementVector * 10);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var collectible = other.GetComponent<Collectible>();
            if (collectible != null)
            {
                Events.OnScoreAdded.Execute(10);
                Destroy(other.gameObject);
            }
        }
    }
}