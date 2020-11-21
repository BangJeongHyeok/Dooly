﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class Hoit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        private bool _isBoom = false;

        public void Init()
        {
            _isBoom = false;
            this.transform.localPosition = Vector3.zero;
        }

        private void OnEnable()
        {
            Init();
        }

        private void Update()
        {
            if (_isBoom == false)
            {
                this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
            } 

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
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
    }
}