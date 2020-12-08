using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class GildongManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gildongPanel;
        [SerializeField] private GameObject _gameoverPanel;

        void Start()
        {
            IngameManager.Instance.SetGildongManager(this);
        }

        public void GildongGetSword()
        {
            //Global.PlayNanooManager.SetScore(IngameManager.ScoreManager.GetScore());
            _gildongPanel.SetActive(true);
        }
    }
}