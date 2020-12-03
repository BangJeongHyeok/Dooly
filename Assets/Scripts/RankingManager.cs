using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game {
    public class RankingManager : MonoBehaviour
    {
        [SerializeField] private RankingScroll _rankScroll;

        public void OnClick_Ranking()
        {
            IngameManager.PlayNanooManager.RequestRanking(OnResponseRanking);
        }

        private void OnResponseRanking(ArrayList list)
        {
            IngameManager.PlayNanooManager.WriteRanking();
            _rankScroll.SetRanking(list);
            _rankScroll.gameObject.SetActive(true);
        }
    }
}
