using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Dooly.Game
{
    public class RankingScroll : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        public GameObject _contents;
        [SerializeField] private GameObject _rankingUnit;
        private ArrayList _rankingList;

        //private List<GameObject> _rankingUnitList= new List<GameObject>();
        private List<RankingUnit> _rankingUnitList = new List<RankingUnit>();
        //private Queue<GameObject> _rankingUnitQueue = new Queue<GameObject>();


        private void OnDisable()
        {
        }

        private void OnGUI()
        {
            var ang = _rankingUnitList.OrderByDescending(x => x._score);
            int rank = 1;
            foreach(var k in ang)
            {
                if (!k.gameObject.activeSelf)
                {
                    continue;
                }
                k.SetRanking(rank);
                rank++;
                k.transform.SetAsLastSibling();
            }
        }

        public GameObject CreateRankingUnit()
        {
            var newObj = PhotonNetwork.Instantiate("RankingUnit", Vector3.zero, Quaternion.identity);
            _rankingUnitList.Add(newObj.GetComponent<RankingUnit>());
            return newObj;
        }
    }
}