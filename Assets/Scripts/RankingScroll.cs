using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class RankingScroll : MonoBehaviour
    {
        [SerializeField] private GameObject _contents;
        [SerializeField] private GameObject _rankingUnit;
        private ArrayList _rankingList;

        private List<GameObject> _rankingUnitList= new List<GameObject>();
        private Queue<GameObject> _rankingUnitQueue = new Queue<GameObject>();


        private void OnDisable()
        {
            ReleaseRankingList();
        }

        public void SetRanking(ArrayList list)
        {
            ReleaseRankingList();

            _rankingList = list;

            int ranking = 0;
            foreach (Dictionary<string, object> rank in _rankingList)
            {
                GameObject obj = null;

                if (_rankingUnitQueue.Count > 0)
                {
                    obj = _rankingUnitQueue.Dequeue();
                }
                else
                {
                    CreateRankingUnit();
                    obj = _rankingUnitQueue.Dequeue();
                }

                obj.GetComponent<RankingUnit>().SetRankInfo(++ranking, rank["data"].ToString(), int.Parse(rank["score"].ToString()));
                obj.SetActive(true);

                _rankingUnitList.Add(obj);
            }
        }

        private void CreateRankingUnit()
        {
            var newRankingUnit = Instantiate(_rankingUnit, _contents.transform);
            newRankingUnit.SetActive(false);
            _rankingUnitQueue.Enqueue(newRankingUnit);
        }

        private void ReleaseRankingList()
        {
            foreach (var rank in _rankingUnitList)
            {
                rank.SetActive(false);
            }

            _rankingUnitList.Clear();
        }
    }
}