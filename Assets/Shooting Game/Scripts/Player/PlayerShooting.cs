using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShootingGame
{
    public class PlayerShooting : MonoBehaviour
    {
        public Vector2 currentMousePos;
        [SerializeField] private Transform armTf;
        [SerializeField] private Transform pointAttack;
        [SerializeField] private Transform pointAttackShotgun;
        [SerializeField] private int curGunId;

        public Vector2 curDirection;

        public UnityEvent onKnock = new UnityEvent();
        public WeaponSlot curWeaponSlot;

        private void Start()
        {
            curGunId = 1;
        }

        public void HandleRotationArm()
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(currentMousePos.y - transform.position.y, currentMousePos.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            armTf.rotation = targetRotation;
        }

        public void Shooting()
        {
            curDirection = (currentMousePos - (Vector2)transform.position).normalized;
            BaseGun baseGun = GunController.Ins.gunManager.GetCurrentGun(curGunId);
            if (baseGun.TryGetComponent<GunA>(out GunA gunA))
            {
                gunA.Shoot(curDirection, pointAttack);
                return;
            }
            if (baseGun.TryGetComponent<GunB>(out GunB gunB))
            {
                gunB.Shoot(curDirection, pointAttack);
                return;
            }
            if (baseGun.TryGetComponent<GunC>(out GunC gunC))
            {
                gunC.Shoot(curDirection, pointAttack);
                return;
            }

        }

        public void SetGun(int id)
        {
            curGunId = id;
        }

        public int GetCurrentGun() => curGunId;


    }
}


