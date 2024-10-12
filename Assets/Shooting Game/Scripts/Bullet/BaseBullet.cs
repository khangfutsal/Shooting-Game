using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public abstract class BaseBullet : MonoBehaviour
    {
        public float damageBullet;
        public float speedBullet;
        public float destroy;
        [HideInInspector] public Rigidbody2D rgBody2D;

        public virtual void SetDirection(Vector2 direction)
        {
            transform.right = direction;
        }

    }
}

