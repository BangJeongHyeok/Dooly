using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game {

    public class Gildong : MonoBehaviour
    {
        public Rigidbody2D Bodyrigid;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                IngameManager.HoitManager.InitObject();
                HitBody(Random.Range(10, 80));
            }
        }

        public void HitBody(float HitPower)
        {
            Bodyrigid.AddForce(Vector2.right * HitPower, ForceMode2D.Impulse);
        }
    }
}
