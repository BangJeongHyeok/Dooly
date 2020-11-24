using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class DounerManager : MonoBehaviour
    {
        [SerializeField] private GameObject _dounerPanel;
        [SerializeField] private Animator _dounerAnim;

        private void Start()
        {
            IngameManager.Instance.SetDounerManager(this);
        }

        public void PlayCosmos()
        {
            _dounerPanel.SetActive(true);
            _dounerAnim.Play("TimeCosmos Animation", -1, 0f);
        }
    }
}
