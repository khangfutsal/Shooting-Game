using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public abstract class BaseGun : MonoBehaviour
    {
        public GunSO gunSO;
        [Space(5)]
        
        [SerializeField] protected float speedBullet;

        [SerializeField] protected int amountOfBullet;
        [SerializeField] protected int curAmountOfBullet;

        [SerializeField] protected float timeReload;
        [SerializeField] protected float curTime;

        [SerializeField] protected float shootTime;
        [SerializeField] protected float curShootTime;

        [SerializeField] protected float destroy;

        [SerializeField] protected float damageBullet;

        [SerializeField] protected GameObject bulletObj;

        private void Start()
        {
            LoadVariables();
        }

        public virtual void LoadVariables()
        {
            this.timeReload = gunSO.gunData.timeReload;
            this.curTime = this.timeReload;
            this.speedBullet = gunSO.gunData.speedBullet;
            this.amountOfBullet = gunSO.gunData.amountOfBullet;
            this.curAmountOfBullet = this.amountOfBullet;
            this.bulletObj = gunSO.gunData.bulletObj;
            this.shootTime = gunSO.gunData.shootTime;
            this.destroy = gunSO.gunData.destroy;
            this.damageBullet = gunSO.gunData.damageBullet;
        }

        public abstract void Shoot(Vector2 direction,Transform point);
        public abstract IEnumerator ReloadGun();

        public abstract void HandleBullet(Vector2 direction, Transform point);



    }

}
