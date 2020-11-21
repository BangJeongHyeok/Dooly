using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoitManager : MonoBehaviour
{
    private const string hoitObjName = "HoitParticle"; 

    private Queue<GameObject> _hoitQueue = new Queue<GameObject>();
    [SerializeField] private GameObject _hoitGameObject;

    private void Awake()
    {
        _hoitGameObject = Resources.Load("Prefabs/" + hoitObjName) as GameObject;
    }

    public void SpawnHoit()
    {
        _hoitQueue.Enqueue(CreateObject());
    }

    private GameObject CreateObject()
    {
        var obj = Instantiate(_hoitGameObject);
        obj.SetActive(false);
        obj.transform.SetParent(transform);

        return obj;
    }

    public void InitObject()
    {
        if (_hoitQueue.Count > 0)
        {
            var obj = _hoitQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.SetActive(true);
            //return obj;
        }
        else
        {
            var obj = CreateObject();
            obj.SetActive(true);
            obj.transform.SetParent(null);
            //return newObj;
        }
    }

    public void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        _hoitQueue.Enqueue(obj);
    }
}
