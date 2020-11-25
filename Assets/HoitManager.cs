using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{

    public class HoitManager : MonoBehaviour
    {
        private const string hoitObjName = "HoitParticle";

        private Queue<GameObject> _hoitQueue = new Queue<GameObject>();
        private GameObject _hoitGameObject;

        public void Init()
        {
            _hoitGameObject = Resources.Load("Prefabs/" + hoitObjName) as GameObject;
            CreateObject();
        }

        private GameObject CreateObject()
        {
            var obj = Instantiate(_hoitGameObject);
            obj.SetActive(false);
            obj.transform.SetParent(IngameManager.Instance.Disable.transform);

            _hoitQueue.Enqueue(obj);

            return obj;
        }

        public void SpawnHoit()
        {
            GameObject obj = null;
            if (_hoitQueue.Count > 0)
            {
                obj = _hoitQueue.Dequeue();
            }
            else
            {
                CreateObject();
                obj = _hoitQueue.Dequeue();
            }

            SetHoitTarget(obj);
            obj.transform.SetParent(null);
            obj.SetActive(true);
        }

        public void ReleaseObject(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(IngameManager.Instance.Disable.transform);
            _hoitQueue.Enqueue(obj);
        }

        private void SetHoitTarget(GameObject obj) 
        {
            Hoit hoit = obj.GetComponent<Hoit>();
            Vector2 startPos = IngameManager.DoolyManager.GetHoitPivot();
            GildongBodyPart bodyPart = IngameManager.Gildong.GetBodyParts();

            if (bodyPart == null)
            {
                hoit.SetPos(startPos, IngameManager.Gildong.BodyPivot.transform.position);
            }
            else
            {
                hoit.SetPos(startPos, bodyPart);
            }
        }
    }
}