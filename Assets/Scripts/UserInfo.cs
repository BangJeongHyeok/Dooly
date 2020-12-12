using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Dooly.Game
{
    public class UserInfo : MonoBehaviourPunCallbacks , IPunObservable
    {
        private GameObject myRankingUnitObj = null;
        private RankingUnit myRankingUnit;
        private string name = string.Empty;
        private int score = 0;
        private bool isUnitSpawn = false;
        private void Start()
        {
            CreateRankingUnit();
        }

        private void CreateRankingUnit()
        {
            photonView.RPC("SetMyRankingUnit", RpcTarget.AllViaServer);
        }

        [PunRPC]
        private void SetMyRankingUnit()
        {
            myRankingUnitObj = IngameManager.RankingManager._rankScroll.CreateRankingUnit();
            myRankingUnit = myRankingUnitObj.GetComponent<RankingUnit>();
            myRankingUnitObj.SetActive(false);
            isUnitSpawn = true;
        }

        [PunRPC]
        private void SetActiveMyRankingUnitObj()
        {
            if (myRankingUnitObj != null)
            {
                myRankingUnitObj.SetActive(true);
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(score);
                stream.SendNext(name);
            }
            else
            {
                score = (int)stream.ReceiveNext();
                name = (string)stream.ReceiveNext();
            }
        }

        private void Update()
        {
            if (isUnitSpawn == false)
            {
                return;
            }

            if (photonView.IsMine)
            {
                name = PhotonNetwork.NickName;
                score = IngameManager.ScoreManager.GetScore();
                myRankingUnitObj.SetActive(true);
                photonView.RPC("SetActiveMyRankingUnitObj", RpcTarget.All);
            }

            if (myRankingUnitObj != null)
            {
                myRankingUnit.SetRankInfo(name, score);
            }
        }
    }
}