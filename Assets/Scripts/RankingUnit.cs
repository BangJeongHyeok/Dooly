using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Dooly.Game {
    public class RankingUnit : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private Text _rankText;
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _scoreText;

        public int _score = 0;
        private string _name = string.Empty;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_score);
                stream.SendNext(_name);
            }
            else
            {
                _score = (int)stream.ReceiveNext();
                _name = (string)stream.ReceiveNext();

                SetRankInfo(_name, _score);
            }
        }

        private void Start()
        {
            photonView.RPC("SetParent", RpcTarget.AllViaServer);
        }

        [PunRPC]
        private void SetParent()
        {
            this.gameObject.SetActive(false);
            this.transform.parent = IngameManager.RankingManager._rankScroll._contents.transform;
            this.transform.localPosition = Vector3.zero;
            this.transform.localScale = new Vector3(1, 1, 1);
        }

        public void SetRankInfo(string name, int score)
        {
            _score = score;
            _name = name;

            //_rankText.text = rank.ToString();
            _nameText.text = name;
            _scoreText.text = score.ToString();
        }

        public void SetRanking(int ranking)
        {
            _rankText.text = ranking.ToString();
        }
    }
}
