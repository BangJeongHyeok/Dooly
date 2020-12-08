using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class GameOverAnimationEvent : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GoGameOverScene()
        {
            Global.SceneChanger.ChangeScene("GameOverScene");
        }
    }
}
