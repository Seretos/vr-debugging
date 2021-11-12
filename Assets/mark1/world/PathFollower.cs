﻿using PathCreation;
using Photon.Pun;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(PathCreator))]
    public class PathFollower : MonoBehaviourPunCallbacks
    {
        public float speed = 1.0f;
        public bool running = false;
        protected PathCreator _path;
        
        private float _currentDistance = 0.0f;
        private float _operation = 1.0f;
        protected Position _position;
        
        private void Awake()
        {
            _path = GetComponent<PathCreator>();
            _position = GetComponentInChildren<Position>();
        }

        private void Update()
        {
            if (running && photonView.IsMine)
            {
                _position.blocked = true;
                _currentDistance += (speed * Time.deltaTime) * _operation;
                if (_currentDistance >= _path.path.length)
                {
                    _operation = -1;
                    _currentDistance = _path.path.length;
                    running = false;
                }
                else if (_currentDistance < 0.0f)
                {
                    _operation = 1;
                    _currentDistance = 0.0f;
                    running = false;
                }
                
                _position.transform.position = 
                    _path.path.GetPointAtDistance(_currentDistance, EndOfPathInstruction.Stop); 
                _position.transform.rotation = 
                    _path.path.GetRotationAtDistance(_currentDistance, EndOfPathInstruction.Stop);
            } else if (photonView.IsMine)
            {
                _position.blocked = false;
            }
            SetAnchorPosition();
        }

        protected virtual void SetAnchorPosition()
        {
            
        }
    }
}