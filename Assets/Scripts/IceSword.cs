using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game {
    public class IceSword : MonoBehaviour
    {
        private float speed;

        private void SetSpeed()
        {
            speed = 5 + IngameManager.ScoreManager.GetScore() / 50 * 100;
        }

        // Update is called once per frame
        void Update()
        {
            SetSpeed();
            
            this.transform.Rotate(new Vector3(0, 0, -500.0f * Time.deltaTime));

            Vector3 dir = Camera.main.WorldToViewportPoint(IngameManager.Gildong.BodyPivot.transform.position) - this.transform.position;
            //dir.Normalize();

            this.transform.position += dir.normalized * Time.deltaTime * speed;
        }

        public void BlockingSword()
        {
            this.gameObject.SetActive(false);
        }
    }
}