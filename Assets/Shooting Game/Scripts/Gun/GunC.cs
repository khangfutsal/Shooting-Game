using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace ShootingGame
{
    public class GunC : BaseGun
    {
        private bool isDone;
        private Coroutine coroutine;

        private void Update()
        {
            if (curShootTime <= 0)
            {
                isDone = true;
                return;
            }
            curShootTime -= Time.deltaTime;

        }
        public override void HandleBullet(Vector2 direction, Transform point)
        {
            curAmountOfBullet--;
            GameObject bulletObj = ObjectPool.Ins.SpawnFromPool(base.bulletObj.name, point.position, Quaternion.identity);
            BulletC bulletC = bulletObj.GetComponent<BulletC>();
            bulletC.destroy = destroy;
            bulletC.SetSpeedBullet = speedBullet;
            bulletC.SetDirection(direction);

            var player = GameObject.Find("Player");
            player.GetComponent<PlayerShooting>().onKnock?.Invoke();
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

        public override void Shoot(Vector2 direction, Transform point)
        {
            Debug.Log("GunC Shoot");
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

        public bool CanShoot()
        {
            return curAmountOfBullet > 0;
        }
    }

}
