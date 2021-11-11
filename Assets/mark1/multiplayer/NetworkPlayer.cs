using mark1.world;
using Photon.Pun;
using UnityEngine;

namespace mark1.multiplayer
{
    [RequireComponent(typeof(BoxCollider))]
    public class NetworkPlayer : MonoBehaviourPunCallbacks
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

        private BoxCollider _collider;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
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

            Vector3 centerPos = transform.InverseTransformPoint(networkBody.position);
            centerPos = new Vector3(centerPos.x, 0.0f, centerPos.z);
            _collider.center = centerPos;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Position>())
            {
                transform.parent = other.transform;
            }
        }
    }
}