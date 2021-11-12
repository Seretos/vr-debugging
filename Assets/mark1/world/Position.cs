using System;
using Photon.Pun;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(BoxCollider))]
    public class Position : MonoBehaviourPunCallbacks
    {
        public Transform anchor;
        private AreaGroup _areaGroup;

        private void Start()
        {
            _areaGroup = GetComponentInParent<AreaGroup>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>() && _areaGroup)
            {
                _areaGroup.PlayerEnterGroup();
            }
        }
    }
}