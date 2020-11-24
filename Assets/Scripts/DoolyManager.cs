using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class DoolyManager : MonoBehaviour
    {
        [SerializeField]private GameObject HoitPivot;

        private void Start()
        {
            IngameManager.Instance.SetDoolyManager(this);
        }

        public Vector2 GetHoitPivot()
        {
            return HoitPivot.transform.position;
        }
    }
}