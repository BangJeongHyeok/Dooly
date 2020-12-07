using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game {
    public class IceSword : MonoBehaviour
    {
        private float speed;

        private void SetSpeed()
        {
            speed = 5 + IngameManager.ScoreManager.GetScore() / 50 * 10;
        }

        // Update is called once per frame
        void Update()
        {
            SetSpeed();
            
            this.transform.Rotate(new Vector3(0, 0, -500.0f * Time.deltaTime));

            Vector3 dir = IngameManager.Gildong.BodyPivot.transform.position - this.transform.position;
            dir.z = 0;
            this.transform.position += dir.normalized * Time.deltaTime * speed;

            float distance = Vector2.Distance(this.transform.position, IngameManager.Gildong.BodyPivot.transform.position);

            if (distance < 0.1f)
            {
                IngameManager.GildongManager.GildongGetSword();
            }
        }

        public void BlockingSword()
        {
            this.gameObject.SetActive(false);
        }
    }
}