using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game {

    public class Gildong : MonoBehaviour
    {
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
                IngameManager.HoitManager.InitObject();
                HitBody(Random.Range(10, 60));//리지드 애드포스
                IngameManager.Instance.scoretext.GetScore(++IngameManager.Instance.Score);//점수
                StateChecker();//고길동 체력

            }
        }

        public void HitBody(float HitPower)
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

        public void GetNewBody(GameObject GildongBody)
        {
            for (int i = 0; i < GildongBody.transform.GetChild(0).transform.childCount; i++)
            {
                HingeJoint2D hinge = GildongBody.transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<HingeJoint2D>();
                BodyParts.Add(hinge);
            }
        }

        public void BodySlash()
        {
            if (BodyParts.Count > 0)
            {
                for (int i = 0; i < BodyParts.Count; i++)
                    BodyParts[i].enabled = false;

                BodyParts.Clear();
            }
        }
    }
}
