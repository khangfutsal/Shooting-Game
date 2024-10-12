using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class BuffManager : MonoBehaviour
    {
        [SerializeField] private List<BaseBuff> listBuffs;
        public List<BaseBuff> GetListBuffs() => listBuffs;


        public BaseBuff GetCurrentBuff(int id)
        {
            return listBuffs.Find(a => a.buffSO.buffData.id == id);
        }
    }
}

