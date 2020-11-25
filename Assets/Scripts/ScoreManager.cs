using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dooly.Game {
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private ScoreText scoretext;
        private int _score = 0;

        public void Start()
        {
            IngameManager.Instance.SetScoreManager(this);
        }

        public void AddScore(int score)
        {
            _score += score;
            scoretext.ApplyScore(_score);
        }
    }
}