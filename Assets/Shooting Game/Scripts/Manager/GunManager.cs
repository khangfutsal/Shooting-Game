using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class GunManager : MonoBehaviour
    {
        [SerializeField] private List<BaseGun> listGuns;
        public List<BaseGun> GetListGuns() => listGuns;

        public BaseGun GetCurrentGun(int id)
        {
            return listGuns.Find(a => a.gunSO.gunData.id == id);
        }
    }
}

