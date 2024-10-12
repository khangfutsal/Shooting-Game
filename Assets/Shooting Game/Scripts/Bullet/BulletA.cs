using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class BulletA : BaseBullet
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
            ObjectPool.Ins.ReturnToPool("Bullet1", this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.ENEMYTAG))
            {
                Debug.Log("ENemy");
                ITakeDamage damage = collision.GetComponent<ITakeDamage>();
                if (damage != null)
                {
                    damage.TakeDamage(damageBullet);
                    isActive = false;
                    ObjectPool.Ins.ReturnToPool("Bullet1", this.gameObject);
                }
            }
        }
    }
}

