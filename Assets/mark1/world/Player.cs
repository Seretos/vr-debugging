using System.Collections.Generic;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Player : MonoBehaviour
    {
        public Transform bodyPosition;
        public Transform playArea;
        
        private BoxCollider _collider;
        private List<Position> _enteredPositions;
        private Position _currentPosition;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
            _enteredPositions = new List<Position>();
        }

        private void Update()
        {
            Vector3 centerPos = transform.InverseTransformPoint(bodyPosition.position);
            centerPos = new Vector3(centerPos.x, 0.0f, centerPos.z);
            _collider.center = centerPos;

            if (_currentPosition)
            {
                if (!_enteredPositions.Contains(_currentPosition))
                {
                    _currentPosition = null;
                    playArea.parent = null;
                }
            }
            
            if (!_currentPosition)
            {
                foreach (Position enteredPosition in _enteredPositions)
                {
                    _currentPosition = enteredPosition;
                    playArea.parent = _currentPosition.anchor;
                    break;
                }
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Position pos = other.GetComponent<Position>();
            if (pos && !pos.blocked)
            {
                if(!_currentPosition || !_currentPosition.blocked)
                    _enteredPositions.Add(pos);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Position>())
            {
                _enteredPositions.Remove(other.GetComponent<Position>());
            }
        }
    }
}