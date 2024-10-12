using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    [Serializable]
    public class GunData
    {
        public string name;
        public int id;
        public int amountOfBullet;
        public float shootTime;
        public float timeReload;
        public float speedBullet;
        public float damageBullet;
        public float destroy;
        public bool canShoot;
        public GameObject bulletObj;
    }
}

