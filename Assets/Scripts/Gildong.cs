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

        void StateChecker()
        {
            Life -= (Random.Range(0, 3)+1);
            if (Life <= 0)
            {
                BodySlash();
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

        public void BodySlash()//사지절단
        {
            if (BodyParts.Count > 0)
            {
                for (int i = 0; i < BodyParts.Count; i++)
                    BodyParts[i].enabled = false;

                BodyParts.Clear();
            }
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
