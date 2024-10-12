using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    [CreateAssetMenu(menuName ="ScriptableObject/GunData",fileName = "GunData",order = 1)]
    public class GunSO : ScriptableObject
    {
        public GunData gunData;
    }

}
