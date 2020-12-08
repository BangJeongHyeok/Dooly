using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly
{
    public class Global : MonoBehaviour
    {
        public static Global Instance
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

        public static SceneChanger SceneChanger => _sceneChanger;

        private static Global _instance;
        private static SceneChanger _sceneChanger;

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

            _sceneChanger = new SceneChanger();
        }
    }
}
