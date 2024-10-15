using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace ShootingGame
{
    public class BulletC : BaseBullet
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
            rgBody2D.velocity = direction;
            transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 6).OnComplete(() =>
            {
                transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f);
                InactiveBullet();
            });
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
            ObjectPool.Ins.ReturnToPool("Bullet3", this.gameObject);
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
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.ENEMYTAG))
            {
                Debug.Log("ENemy");
                ITakeDamage damage = collision.GetComponent<ITakeDamage>();
                if (damage != null)
                {
                    damage.TakeDamage(damageBullet);
                }
            }
        }
    }
}

