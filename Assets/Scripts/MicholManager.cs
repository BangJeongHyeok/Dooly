using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dooly.Game {
    public class MicholManager : MonoBehaviour
    {
        [SerializeField] private GameObject _MicholPivot;
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
                int RandomPos = Random.Range(0, 4);
                switch (RandomPos)
                {
                    case 0:
                        _MicholPivot.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(0, 0, 0));
                        _MicholPivot.transform.localScale = new Vector3(-1, 1, 1);
                        break;
                    case 1:
                        _MicholPivot.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(0, 1, 0));
                        _MicholPivot.transform.localScale = new Vector3(-1, -1, 1);
                        break;
                    case 2:
                        _MicholPivot.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(1, 0, 0));
                        _MicholPivot.transform.localScale = new Vector3(1, 1, 1);
                        break;
                    case 3:
                        _MicholPivot.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(1, 1, 0));
                        _MicholPivot.transform.localScale = new Vector3(1, -1, 1);
                        break;
                }
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
