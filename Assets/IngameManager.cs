using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class IngameManager : MonoBehaviour
    {
        public IngameManager Instance
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
        public HoitManager HoitManager { get; set; }

        private static IngameManager _instance; 
        private HoitManager _hoitManager;

        private void Awake()
        {
            _instance = this;
            _hoitManager = new HoitManager();

            SetManager();
        }

        private void SetManager()
        {
            HoitManager = _hoitManager;
        }
    }
}