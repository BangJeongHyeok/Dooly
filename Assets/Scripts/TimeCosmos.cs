using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dooly.Game
{
    public class TimeCosmos : MonoBehaviour
    {
        public void ResurrectionGildong()
        {
            IngameManager.Gildong.GetNewBody();
            this.gameObject.SetActive(false);
        }
    }
}
