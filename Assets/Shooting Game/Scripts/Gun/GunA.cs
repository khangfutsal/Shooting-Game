using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class GunA : BaseGun
    {
        private bool isDone;
        private Coroutine coroutine;
        public override void HandleBullet(Vector2 direction,Transform point)
        {
            curAmountOfBullet--;
            GameObject bulletObj = ObjectPool.Ins.SpawnFromPool(base.bulletObj.name, point.position, Quaternion.identity);
            BulletA bulletA = bulletObj.GetComponent<BulletA>();
            bulletA.damageBullet = damageBullet;
            bulletA.destroy = destroy;
            bulletA.SetSpeedBullet = speedBullet;
            bulletA.SetDirection(direction);
        }

        public override void Shoot(Vector2 direction, Transform point)
        {
            if (CanShoot() && isDone)
            {
                isDone = false;
                
                curShootTime = shootTime;
                HandleBullet(direction,point);
                
                
            }
            else if (!CanShoot() && coroutine == null)
            {
                coroutine = StartCoroutine(ReloadGun());
            }

        }

        private void Update()
        {
            if (curShootTime <= 0)
            {
                isDone = true;
                return;
            }
            curShootTime -= Time.deltaTime;
            
        }

        public override IEnumerator ReloadGun()
        {
            Debug.Log("Reload");
            yield return new WaitForSeconds(timeReload);
            curShootTime = 0;
            curAmountOfBullet = amountOfBullet;
            coroutine = null;

        }


        public bool CanShoot()
        {
            return curAmountOfBullet > 0;
        }



    }
}

