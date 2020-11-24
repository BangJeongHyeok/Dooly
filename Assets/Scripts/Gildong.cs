using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{

    public class Gildong : MonoBehaviour
    {
        public GameObject BodyPivot;
        [SerializeField] private List<GildongBodyPart> _bodyParts = new List<GildongBodyPart>();
        private Stack<GildongBodyPart> _bodyPartsStack = new Stack<GildongBodyPart>();

        private void Start()
        {
            GetNewBody(Gildong_obj);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HitBody(Random.Range(10, 60));//리지드 애드포스
                IngameManager.HoitManager.SpawnHoit();
                IngameManager.Instance.scoretext.GetScore(++IngameManager.Instance.Score);//점수
                StateChecker();//고길동 체력

            }
        }

        public void HitBody(float HitPower)//폭력
        {
            Bodyrigid.AddForce(Vector2.right * HitPower + (Vector2.up * Random.Range(-50f,50f)), ForceMode2D.Impulse);
        }

        private IEnumerator ResetPart()
        {
            for (int i = 0; i < _bodyParts.Count; i++)
            {
                _bodyParts[i].ResetPart();

                yield return new WaitForSeconds(0.05f);
            }
        }

        private void ReConnectParts()
        {
            _bodyPartsStack.Clear();

            foreach (var part in _bodyParts)
            {
                part.ReConnectPart();
                _bodyPartsStack.Push(part);
            }
        }

        private IEnumerator WaitRewindBody()
        {
            while (true)
            {
                bool AllReset = true;

                for (int i = 0; i < _bodyParts.Count; i++)
                {
                    if (_bodyParts[i].CheckAllReset() == false)
                    {
                        AllReset = false;
                    }
                }

                if (AllReset)
                {
                    break;
                }

                yield return new WaitForSeconds(0.3f);
            }

            ReConnectParts();
        }

        public GildongBodyPart GetBodyParts()
        {
            if (_bodyPartsStack.Count > 0)
            {
                GildongBodyPart bodyPart = _bodyPartsStack.Pop();
                return bodyPart;
            }
            else
            {
                IngameManager.DounerManager.PlayCosmos();
            }
            return null;
        }
    }
}
