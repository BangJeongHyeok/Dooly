using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dooly {
    public class RegistRanking : MonoBehaviour
    {
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _scoreText;

        private void Awake()
        {
            //Global.PlayNanooManager.Init();
            //_scoreText.text = Global.PlayNanooManager.GetScore().ToString();
        }

        public void WriteRanking()
        {
            //Global.PlayNanooManager.SetName(_nameText.text);
            //Global.PlayNanooManager.WriteRanking();
        }
    }
}
