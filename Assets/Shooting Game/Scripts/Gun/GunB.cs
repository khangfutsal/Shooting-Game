using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class GunB : BaseGun
    {
        private bool isDone;
        private Coroutine coroutine;
        public override void Shoot(Vector2 direction, Transform point)
        {
            if (CanShoot() && isDone)
            {
                HandleBullet(direction, point);
                isDone = false;
                curShootTime = shootTime;
            }
            else if (!CanShoot() && coroutine == null)
            {
                coroutine = StartCoroutine(ReloadGun());
            }
        }

        public override void HandleBullet(Vector2 direction, Transform point)
        {
            curAmountOfBullet--;
            GameObject bulletObj = ObjectPool.Ins.SpawnFromPool(base.bulletObj.name, point.position, Quaternion.identity);
            BulletB bulletB = bulletObj.GetComponent<BulletB>();
            bulletB.destroy = destroy;
            bulletB.SetSpeedBullet = speedBullet;
            bulletB.SetDirection(direction);
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
            UIController.Ins.manager.GetGamePlayUI().ShowReloadingText();
            yield return new WaitForSeconds(timeReload);
            curShootTime = 0;
            curAmountOfBullet = amountOfBullet;
            coroutine = null;
            UIController.Ins.manager.GetGamePlayUI().HideReloadingText();

        }

        public bool CanShoot()
        {
            return curAmountOfBullet > 0;
        }

    }
}


