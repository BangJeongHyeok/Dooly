using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dooly.Game
{
    public class MicholManager : MonoBehaviour
    {
        [SerializeField] private GameObject _micholButton;
        [SerializeField] private Animator _micholAnim;

        bool MicholOn = false;

        void Start()
        {
            StartCoroutine(Michol_GetOut());
        }

        void Update()
        {
        }

        IEnumerator Michol_GetOut()
        {
            yield return new WaitForSeconds(Random.Range(3f, 7f));
            if (!IngameManager.DounerManager.IsPlayingCosmos)
            {
                _micholButton.SetActive(true);
                MicholOn = true;
                _micholAnim.SetBool("MicholOn", MicholOn);
            }
            StartCoroutine(Michol_GetOut());
        }

        public void Michol_Getin()
        {
            if (MicholOn)
            {
                MicholOn = false;
                _micholAnim.SetBool("MicholOn", MicholOn);
            }
        }
    }
}
