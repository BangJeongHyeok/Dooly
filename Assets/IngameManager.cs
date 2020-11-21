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
        public static HoitManager HoitManager { get; set; }

        private static IngameManager _instance; 
        private static HoitManager _hoitManager;


        private void Awake()
        {
            _instance = this;
            _hoitManager = new HoitManager();

            SetManager();
            InitManager();
        }

        private void SetManager()
        {
            HoitManager = _hoitManager;
        }

        private void InitManager()
        {
            _hoitManager.Init();
        }
    }
}