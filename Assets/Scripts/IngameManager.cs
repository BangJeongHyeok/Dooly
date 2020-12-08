using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class IngameManager : MonoBehaviour
    {
        public GameObject Disable;

        public static IngameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    return null;
                }
                return _instance;
            }
        }
        public static HoitManager HoitManager => _hoitManager;
        public static DoolyManager DoolyManager => _doolyManager;
        public static Gildong Gildong => _gildong;
        public static DounerManager DounerManager => _dounerManager;
        public static ScoreManager ScoreManager => _scoreManager;
        public static GildongManager GildongManager => _gildongManager;


        private static IngameManager _instance; 
        private static HoitManager _hoitManager;
        private static DoolyManager _doolyManager;
        private static Gildong _gildong;
        private static DounerManager _dounerManager;
        private static ScoreManager _scoreManager;
        private static GildongManager _gildongManager;

        private void Awake()
        {
            _instance = this;
            _hoitManager = new HoitManager();

            SetManager();
            InitManager();
        }

        private void SetManager()
        {
        }

        private void InitManager()
        {
            _hoitManager.Init();
            Global.PlayNanooManager.Init();
        }

        public void SetDoolyManager(DoolyManager dooly)
        {
            _doolyManager = dooly;
        }

        public void SetGildong(Gildong gildong)
        {
            _gildong = gildong;
        }

        public void SetDounerManager(DounerManager douner)
        {
            _dounerManager = douner;
        }

        public void SetScoreManager(ScoreManager score)
        {
            _scoreManager = score;
        }

        public void SetGildongManager(GildongManager gildong)
        {
            _gildongManager = gildong;
        }
    }
}