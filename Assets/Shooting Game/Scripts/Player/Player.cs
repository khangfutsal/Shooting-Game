using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootingGame
{
    public class Player : MonoBehaviour,IShopCustomer
    {

        private const int playerLayer = 8;
        private const int enemyLayer = 6;
        #region Player Component
        public PlayerMove playerMove;
        public PlayerShooting playerShooting;
        public PlayerHealth playerHealth;
        public PlayerBuff playerBuff;
        #endregion

        public bool isKnock;

        [SerializeField] private float colorLerpSpeed;

        private bool isDeath;
        public bool isShieldActive;
        private WeaponSlot curWeaponSlot;

        #region Unity Component
        [SerializeField] private SpriteRenderer HeadSprite;
        [SerializeField] private SpriteRenderer BodySprite;
        [SerializeField] private SpriteRenderer ArmSprite;


        private Rigidbody2D rigidbody2D;


        #endregion

        private float timeKnockBack;
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();

            playerMove = GetComponent<PlayerMove>();
            playerShooting = GetComponent<PlayerShooting>();
            playerHealth = GetComponent<PlayerHealth>();
            playerBuff = GetComponent<PlayerBuff>();
        }

        private void Start()
        {
            playerShooting.onKnock.AddListener(() =>
            {
                StartCoroutine(KnockBack());
            });

            playerHealth.onDeath.AddListener(() =>
            {
                StartCoroutine(Death());
            });

            WaveSpawn.onWin.AddListener(() =>
            {
                playerMove.LockAxisRigidBody2D();
            });


            timeKnockBack = 0.3f;
            curWeaponSlot = UIController.Ins.manager.GetGamePlayUI().weaponSlotsUI.GetWeaponSlot(1);
        }

        private void Update()
        {
            HandleFunctionUpdate();
        }

        private void FixedUpdate()
        {
            HandleFunctionFixedUpdate();
        }

        private void HandleFunctionUpdate()
        {
            if (isDeath) return;
            if (EventSystem.current.IsPointerOverGameObject()) return;
            PlayerShootingFunction();
        }

        private void HandleFunctionFixedUpdate()
        {
            if (isDeath)
            {
                return;
            }
            PlayerMoveFunction();
        }

        public IEnumerator Death()
        {
            playerMove.LockAxisRigidBody2D();
            isDeath = true;
            bool isDoneAnimation = false;

            Vector3 InspireQuaternion = new Vector3(0, 0, 90);
            float duration = 1f;
            transform.DORotate(InspireQuaternion, duration).OnComplete(() =>
            {
                isDoneAnimation = true;
            });

            yield return new WaitUntil(() => isDoneAnimation);
            UIController.Ins.manager.GetLoseUI().Show();

        }

        #region Player Shooting Function
        public void PlayerShootingFunction()
        {
            playerShooting.HandleRotationArm();
            UpdateAmmo();
            if (Input.GetMouseButton(0))
            {
                playerShooting.Shooting();
            }
            InputWeaponGun();
        }

        public void UpdateAmmo()
        {
            curWeaponSlot.UpdateTextAmmo(playerShooting.curGun.GetAmountOfBullet());
        }

        public void InputWeaponGun()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var gunID = 1;
                var weaponSlot = UIController.Ins.manager.GetGamePlayUI().weaponSlotsUI.GetWeaponSlot(gunID);
                if (weaponSlot.GetUnlockWeapon)
                {
                    playerShooting.SetGun(gunID);
                    curWeaponSlot.HideUsingImage();
                    weaponSlot.ShowUsingImage();
                    curWeaponSlot = weaponSlot;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var gunID = 2;
                var weaponSlot = UIController.Ins.manager.GetGamePlayUI().weaponSlotsUI.GetWeaponSlot(gunID);
                if (weaponSlot.GetUnlockWeapon)
                {
                    playerShooting.SetGun(gunID);
                    curWeaponSlot.HideUsingImage();
                    weaponSlot.ShowUsingImage();
                    curWeaponSlot = weaponSlot;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                var gunID = 3;
                var weaponSlot = UIController.Ins.manager.GetGamePlayUI().weaponSlotsUI.GetWeaponSlot(gunID);
                if (weaponSlot.GetUnlockWeapon)
                {
                    playerShooting.SetGun(gunID);
                    curWeaponSlot.HideUsingImage();
                    weaponSlot.ShowUsingImage();
                    curWeaponSlot = weaponSlot;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                playerShooting.SetGun(4);
            }
        }

        public IEnumerator KnockBack()
        {
            isKnock = true;
            rigidbody2D.velocity = (-playerShooting.curDirection * 5);
            yield return new WaitForSeconds(timeKnockBack);
            isKnock = false;
        }
        #endregion

        #region Player Move Function

        private void PlayerMoveFunction()
        {
            MoveDirection();
        }

        private void MoveDirection()
        {
            if (isKnock)
            {
                return;
            }
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");
            Vector2 vMove = new Vector2(xAxis, yAxis);

            playerMove.Movement(vMove);
        }

        #endregion

        #region Player Buff Function

        public void ActiveShieldBuff()
        {
            isShieldActive = true;
            StopAllCoroutines(); 
            Color inspireColor = new Color(0.4920256f, 0.8698056f, 0.9622642f);
            StartCoroutine(LerpColor(inspireColor)); 
        }

        public void RemoveShieldBuff()
        {
            isShieldActive = false;
            StopAllCoroutines(); 
            StartCoroutine(LerpColor(Color.white)); 
        }

        private IEnumerator LerpColor(Color targetColor)
        {
            float time = 0f;
            Color headStartColor = HeadSprite.color;
            Color bodyStartColor = BodySprite.color;
            Color armStartColor = ArmSprite.color;

            while (time < 1f)
            {
                time += Time.deltaTime * colorLerpSpeed;
                HeadSprite.color = Color.Lerp(headStartColor, targetColor, time);
                BodySprite.color = Color.Lerp(bodyStartColor, targetColor, time);
                ArmSprite.color = Color.Lerp(armStartColor, targetColor, time);
                yield return null;
            }

            HeadSprite.color = targetColor;
            BodySprite.color = targetColor;
            ArmSprite.color = targetColor;
        }



        #endregion

        public void BoughtItem(ItemType item)
        {
            Debug.Log("Test : " + item);
            HandleItem(item);
        }

        public void HandleItem(ItemType item)
        {
            switch (item)
            {
                case ItemType.MGGun:
                    {
                        var mgGunID = 2;
                        var weaponSlot = UIController.Ins.manager.GetGamePlayUI().weaponSlotsUI.GetWeaponSlot(mgGunID);
                        var gun = GunController.Ins.gunManager.GetCurrentGun(mgGunID);
                        weaponSlot.GetUnlockWeapon = true;
                        weaponSlot.HideUnlockImage();
                        weaponSlot.ShowGunImage();
                        weaponSlot.UpdateTextAmmo(gun.GetAmountOfBullet());
                        break;
                    }
                case ItemType.SMGGun:
                    {
                        var SMGGunID = 3;
                        var weaponSlot = UIController.Ins.manager.GetGamePlayUI().weaponSlotsUI.GetWeaponSlot(SMGGunID);
                        var gun = GunController.Ins.gunManager.GetCurrentGun(SMGGunID);
                        weaponSlot.GetUnlockWeapon = true;
                        weaponSlot.HideUnlockImage();
                        weaponSlot.ShowGunImage();
                        weaponSlot.UpdateTextAmmo(gun.GetAmountOfBullet());
                        break;
                    }
            }
        }

        public bool TrySpendGoldAmount(int goldAmount)
        {
            var currentGold = GameController.Ins.manager.GetCurrentGold();
            if(currentGold >= goldAmount)
            {
                GameController.Ins.manager.MinusGold(goldAmount);
                return true;
            }
            return false;
        }
    }
}

