using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class Hoit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        private Vector2[] point = new Vector2[4];

        [Range(0, 1)] private float t = 0;
        private float spd = 3.0f;
        private float posA = 1.55f;
        private float posB = 1.45f;

        private bool _isBoom = false;

        private Vector2 _startPos;
        private Vector2 _targetPos;
        private GildongBodyPart _targetPart;

        public void SetPos(Vector2 startPos, GildongBodyPart targetPart)
        {
            _startPos = startPos;

            if (targetPart != null)
            {
                _targetPos = targetPart.transform.position;
                _targetPart = targetPart;
            }
        }
        public void SetPos(Vector2 startPos, Vector2 targetPos)
        {
            _startPos = startPos;
            _targetPos = targetPos;
            _targetPart = null;
        }

        public void Init()
        {
            _isBoom = false;
            this.transform.position = _startPos;

            t = 0;

            point[0] = _startPos; // P0
            point[1] = PointSetting(_startPos); // P1
            point[2] = PointSetting(_targetPos); // P2
            point[3] = _targetPos; // P3
        }

        private void OnEnable()
        {
            Init();
        }

        private void Update()
        {
            if (_isBoom == false)
            {
                t += Time.deltaTime * spd;
                DrawTrajectory();
            }
            if (t >= 1.0f)
            {
                //IngameManager.HoitManager.ReleaseObject(this.gameObject);
                StartCoroutine(Boom());
            }
        }

        private IEnumerator Boom()
        {
            _isBoom = true;
            _particle.Play();

            yield return new WaitForSeconds(1.0f);
            IngameManager.HoitManager.ReleaseObject(this.gameObject);
        }

        private Vector2 PointSetting(Vector2 origin)
        {
            float x, y;

            x = posA * Mathf.Cos(Random.Range(0, 360) * Mathf.Deg2Rad)
                + origin.x;
            y = posB * Mathf.Sin(Random.Range(0, 360) * Mathf.Deg2Rad)
                + origin.y;
            return new Vector2(x, y);
        }

        private void DrawTrajectory()
        {
            this.transform.position = new Vector2(
                FourPointBezier(point[0].x, point[1].x, point[2].x, point[3].x),
                FourPointBezier(point[0].y, point[1].y, point[2].y, point[3].y)
            );
        }

        private float FourPointBezier(float a, float b, float c, float d)
        {
            return Mathf.Pow((1 - t), 3) * a
                    + Mathf.Pow((1 - t), 2) * 3 * t * b
                    + Mathf.Pow(t, 2) * 3 * (1 - t) * c
                    + Mathf.Pow(t, 3) * d;
        }
    }
}