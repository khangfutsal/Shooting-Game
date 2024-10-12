using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootingGame
{
    public class Player : MonoBehaviour,IShopCustomer
    {

        private const int playerLayer = 8;
        private const int enemyLayer = 9;
        #region Player Component
        public PlayerMove playerMove;
        public PlayerShooting playerShooting;
        public PlayerHealth playerHealth;
        public PlayerBuff playerBuff;
        #endregion

        public bool isKnock;

        [SerializeField] private float colorLerpSpeed;
        private WeaponSlot curWeaponSlot;

        #region Unity Component
        [SerializeField] private SpriteRenderer HeadSprite;
        [SerializeField] private SpriteRenderer BodySprite;
        [SerializeField] private SpriteRenderer ArmSprite;


        private BoxCollider2D boxCollider2D;
        private Rigidbody2D rigidbody2D;


        #endregion

        private float timeKnockBack;
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            boxCollider2D = GetComponent<BoxCollider2D>();

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
            timeKnockBack = 0.3f;
            curWeaponSlot = UIController.Ins.manager.GetWeaponSlotUI().GetWeaponSlot(1);
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
            if (EventSystem.current.IsPointerOverGameObject()) return;
            PlayerShootingFunction();
        }

        private void HandleFunctionFixedUpdate()
        {
            PlayerMoveFunction();
        }

        #region Player Shooting Function
        public void PlayerShootingFunction()
        {
            playerShooting.HandleRotationArm();

            if (Input.GetMouseButton(0))
            {
                playerShooting.Shooting();
            }
            InputWeaponGun();
        }

        public void InputWeaponGun()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var gunID = 1;
                var weaponSlot = UIController.Ins.manager.GetWeaponSlotUI().GetWeaponSlot(gunID);
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
                var weaponSlot = UIController.Ins.manager.GetWeaponSlotUI().GetWeaponSlot(gunID);
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
                var weaponSlot = UIController.Ins.manager.GetWeaponSlotUI().GetWeaponSlot(gunID);
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
            if (isKnock) return;
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");
            Vector2 vMove = new Vector2(xAxis, yAxis);

            playerMove.Movement(vMove);
        }

        #endregion

        #region Player Buff Function

        public void ActiveShieldBuff()
        {
            Physics.IgnoreLayerCollision(playerLayer, enemyLayer, true);
            StopAllCoroutines(); 
            Color inspireColor = new Color(0.4920256f, 0.8698056f, 0.9622642f);
            StartCoroutine(LerpColor(inspireColor)); 
        }

        public void RemoveShieldBuff()
        {
            Physics.IgnoreLayerCollision(playerLayer, enemyLayer, false);
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
                        var weaponSlot = UIController.Ins.manager.GetWeaponSlotUI().GetWeaponSlot(mgGunID);
                        weaponSlot.GetUnlockWeapon = true;
                        weaponSlot.HideUnlockImage();
                        break;
                    }
                case ItemType.SMGGun:
                    {
                        var SMGGunID = 3;
                        var weaponSlot = UIController.Ins.manager.GetWeaponSlotUI().GetWeaponSlot(SMGGunID);
                        weaponSlot.GetUnlockWeapon = true;
                        weaponSlot.HideUnlockImage();
                        break;
                    }
            }
        }

        public bool TrySpendGoldAmount(int goldAmount)
        {
            bool a = false;
            return a;
            //if()
        }
    }
}

