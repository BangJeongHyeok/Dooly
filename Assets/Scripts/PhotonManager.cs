using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Dooly {
    public class PhotonManager : MonoBehaviourPunCallbacks
    {
        private const byte MaxPlayer = 20;
        //private string _name = string.Empty;

        public void Init()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "1";
            //PhotonNetwork.NickName = _name;
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connect To Master");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("Create Room");
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayer });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined Room");
            //Global.SceneChanger.ChangeScene("SampleScene");
            PhotonNetwork.LoadLevel("SampleScene");
        }

        public void Connect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}