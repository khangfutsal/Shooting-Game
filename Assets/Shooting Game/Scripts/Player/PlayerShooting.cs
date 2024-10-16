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

        [SerializeField] private Camera camera;

        public Vector2 curDirection;

        public UnityEvent onKnock = new UnityEvent();
        public WeaponSlot curWeaponSlot;
        public BaseGun curGun;

        private void Start()
        {
            SetGun(1);
        }

        public void HandleRotationArm()
        {
            currentMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(currentMousePos.y - transform.position.y, currentMousePos.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            armTf.rotation = targetRotation;
        }

        public void Shooting()
        {
            curDirection = (currentMousePos - (Vector2)transform.position).normalized;

            if (curGun != null) 
            {
                curGun.Shoot(curDirection, pointAttack); 
            }
        }

        public void SetGun(int id)
        {
            curGunId = id;
            BaseGun baseGun = GunController.Ins.gunManager.GetCurrentGun(curGunId); 

            if (baseGun.TryGetComponent<GunA>(out GunA gunA))
            {
                curGun = gunA;  
            }
            else if (baseGun.TryGetComponent<GunB>(out GunB gunB))
            {
                curGun = gunB; 
            }
            else if (baseGun.TryGetComponent<GunC>(out GunC gunC))
            {
                curGun = gunC;  
            }
        }

    }
}


