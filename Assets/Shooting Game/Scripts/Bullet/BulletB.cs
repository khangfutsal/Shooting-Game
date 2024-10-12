using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class BulletB : BaseBullet
    {
        private bool isActive;
        public float SetSpeedBullet
        {
            set { speedBullet = value; }
        }
        private void Awake()
        {
            rgBody2D = GetComponent<Rigidbody2D>();
        }
        public override void SetDirection(Vector2 direction)
        {
            base.SetDirection(direction);
            Debug.Log(speedBullet);
            rgBody2D.velocity = direction * speedBullet;
        }

        private void Update()
        {
            if (!isActive) return;

            if (destroy <= 0)
            {
                InactiveBullet();
                return;
            }

            destroy -= Time.deltaTime;
        }

        private void OnEnable()
        {
            isActive = true;
        }

        public void InactiveBullet()
        {
            isActive = false;
            ObjectPool.Ins.ReturnToPool("Bullet2", this.gameObject);
        }
    }
}

