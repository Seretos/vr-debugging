using System;
using Photon.Pun;
using UnityEngine;
using NetworkPlayer = mark1.multiplayer.NetworkPlayer;

namespace mark1.world
{
    public class AreaGroup : MonoBehaviourPunCallbacks
    {
        public void PlayerEnterGroup()
        {
            photonView.RPC("SetPlayerToGroupRPC", RpcTarget.All, PhotonNetwork.AuthValues.UserId);
        }
        
        [PunRPC]
        public virtual void SetPlayerToGroupRPC(string user)
        {
            foreach (NetworkPlayer networkPlayer in FindObjectsOfType<NetworkPlayer>())
            {
                if (networkPlayer.GetUser() == user)
                {
                    //networkPlayer.transform.parent = transform;
                }
            }
        }
    }
}