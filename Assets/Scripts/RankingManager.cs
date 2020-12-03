using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game {
    public class RankingManager : MonoBehaviour
    {
        [SerializeField] private RankingScroll _rankScroll;
        [SerializeField] private GameObject _margin;

        public void OnClick_Ranking()
        {
            IngameManager.PlayNanooManager.RequestRanking(OnResponseRanking);
        }
        public void OnClick_Margin()
        {
            _rankScroll.gameObject.SetActive(false);
            _margin.SetActive(false);
        }

        private void OnResponseRanking(ArrayList list)
        {
            IngameManager.PlayNanooManager.WriteRanking();
            _rankScroll.SetRanking(list);
            _rankScroll.gameObject.SetActive(true);
            _margin.SetActive(true);
        }
    }
}
