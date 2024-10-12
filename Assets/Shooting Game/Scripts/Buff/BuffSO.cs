using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    [CreateAssetMenu(menuName ="ScriptableObject/Buff",fileName = "Buff",order = 1)]
    public class BuffSO : ScriptableObject
    {
        public BuffData buffData;
    }
}

