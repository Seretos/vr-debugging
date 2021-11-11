using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace mark1.multiplayer
{
    public class SetupMultiplayer : MonoBehaviourPunCallbacks
    {
        public Transform head;
        public Transform body;
        public Transform rightHand;
        public Transform leftHand;
        public Transform playArea;
        private GameObject _networkPlayerInstance;
        
        void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                Debug.Log("connecting to server...");
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("joining room...");
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;
            roomOptions.IsVisible = true;
            roomOptions.IsOpen = true;
            roomOptions.PublishUserId = true;
            string room = "prod";
# if (DEV_ROOM)
            room = "dev";
#endif
            PhotonNetwork.JoinOrCreateRoom(room, roomOptions, TypedLobby.Default);
            Debug.Log("room " + room);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            _networkPlayerInstance =
                PhotonNetwork.Instantiate("generic_avatar", transform.position, transform.rotation);
                
            NetworkPlayer netPlayer = _networkPlayerInstance.GetComponent<NetworkPlayer>();
            netPlayer.head = head;
            netPlayer.body = body;
            netPlayer.rightHand = rightHand;
            netPlayer.leftHand = leftHand;
            netPlayer.playArea = playArea;
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            PhotonNetwork.Destroy(_networkPlayerInstance);
        }
    }
}
