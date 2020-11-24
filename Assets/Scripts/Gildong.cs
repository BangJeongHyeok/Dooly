using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{

    public class Gildong : MonoBehaviour
    {
        public GameObject Gildong_prb;
        public Rigidbody2D Bodyrigid;
        public GameObject Gildong_obj;
        List<HingeJoint2D> BodyParts = new List<HingeJoint2D>();
        int Life = 100;

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

        public void GetNewBody(GameObject GildongBody)//힌지조인트 싹 가져오는거
        {
            for (int i = 0; i < GildongBody.transform.GetChild(0).transform.childCount; i++)
            {
                HingeJoint2D hinge = GildongBody.transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>();
                BodyParts.Add(hinge);
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
