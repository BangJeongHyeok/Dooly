using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Dooly.Game {
    public class RankingManager : MonoBehaviourPunCallbacks
    {
        public RankingScroll _rankScroll;
        [SerializeField] private GameObject _margin;

        private void Start()
        {
            IngameManager.Instance.SetRankingManager(this);
            //_rankScroll.CreateRankingUnit();
        }

        public void OnClick_Ranking()
        {
            _rankScroll.gameObject.SetActive(true);
            _margin.SetActive(true);
        }
        public void OnClick_Margin()
        {
            _rankScroll.gameObject.SetActive(false);
            _margin.SetActive(false);
        }
    }
}
