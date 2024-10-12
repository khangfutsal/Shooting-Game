using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    [Serializable]
    public class WaveData
    {
        public List<GameObject> enemies;
        public float spawnInterval;
        public int count;
    }

}
