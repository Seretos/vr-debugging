using System;
using mark1.world;
using Photon.Pun;
using UnityEngine;

namespace mark1.multiplayer
{
    public class NetworkPlayer : UserBehaviourPunCallbacks
    {
        public Transform head;
        public Transform body;
        public Transform rightHand;
        public Transform leftHand;
        public Transform playArea;

        public Transform networkHead;
        public Transform networkBody;
        public Transform networkRightHand;
        public Transform networkLeftHand;

        private void Start()
        {
            if (photonView.IsMine)
            {
                SetUser(PhotonNetwork.AuthValues.UserId);
            }
        }

        private void Update()
        {
            if (photonView.IsMine)
            {
                networkHead.gameObject.SetActive(false);
                networkBody.gameObject.SetActive(false);
                networkRightHand.gameObject.SetActive(false);
                networkLeftHand.gameObject.SetActive(false);

                transform.position = playArea.position;
                transform.rotation = playArea.rotation;
                transform.localScale = playArea.lossyScale;

                networkHead.position = head.position;
                networkHead.rotation = head.rotation;
                //networkHead.localScale = head.lossyScale;

                networkRightHand.position = rightHand.position;
                networkRightHand.rotation = rightHand.rotation;
                //networkRightHand.localScale = rightHand.lossyScale;

                networkLeftHand.position = leftHand.position;
                networkLeftHand.rotation = leftHand.rotation;
                //networkLeftHand.localScale = leftHand.lossyScale;

                networkBody.position = body.position;
                //networkBody.localScale = body.lossyScale;
                networkBody.rotation = body.rotation;
            }
        }
    }
}