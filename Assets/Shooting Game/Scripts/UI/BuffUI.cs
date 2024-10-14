using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class BuffUI : MonoBehaviour
    {
        [SerializeField] private List<BuffUIItem> listBuffs;

        private void Start()
        {
            foreach(var i in listBuffs)
            {
                Debug.Log(i.nameBuff);
            }
        }

        public BuffUIItem GetCurBuff(string name)
        {
            return listBuffs.Find(buff => buff.nameBuff == name);
        }

    }
}

