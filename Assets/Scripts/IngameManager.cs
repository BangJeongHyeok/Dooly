using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class IngameManager : MonoBehaviour
    {
        public ScoreText scoretext;

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
        public static PlayNanooManager PlayNanooManager => _playNanooManager;
        public static DoolyManager DoolyManager => _doolyManager;

        private static IngameManager _instance; 
        private static HoitManager _hoitManager;
        private static PlayNanooManager _playNanooManager;
        private static DoolyManager _doolyManager;

        [HideInInspector] public int Score = 0;


        private void Awake()
        {
            _instance = this;
            _hoitManager = new HoitManager();
            _playNanooManager = new PlayNanooManager();

            SetManager();
            InitManager();
        }

        private void SetManager()
        {
        }

        private void InitManager()
        {
            _hoitManager.Init();
        }

        public void SetDoolyManager(DoolyManager dooly)
        {
            _doolyManager = dooly;
        }
    }
}