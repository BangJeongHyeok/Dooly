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
        public static PlayNanooManager PlayNanooManager => _playNanooManager;
        public static DoolyManager DoolyManager => _doolyManager;
        public static Gildong Gildong => _gildong;
        public static DounerManager DounerManager => _dounerManager;

        private static IngameManager _instance; 
        private static HoitManager _hoitManager;
        private static PlayNanooManager _playNanooManager;
        private static DoolyManager _doolyManager;
        private static Gildong _gildong;
        private static DounerManager _dounerManager;

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

        public void SetGildong(Gildong gildong)
        {
            _gildong = gildong;
        }

        public void SetDounerManager(DounerManager douner)
        {
            _dounerManager = douner;
        }
    }
}