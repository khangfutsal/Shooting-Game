using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody2D rgBody2D;

        public Vector2 currentVelocity;

        [SerializeField] private float speed;
        [SerializeField] private float speedDefault;
        [SerializeField] private bool isFacingRight = true;

        private void Awake()
        {
            rgBody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            speedDefault = speed;
        }

        public void Movement(Vector2 vMove)
        {
            HandleSide(vMove);
            currentVelocity = vMove.normalized;
            rgBody2D.velocity = currentVelocity * speed;
        }


        public bool IsTurnRight()
        {
            return currentVelocity.x >= 0;
        }

        public void HandleSide(Vector2 vMove)
        {
            if (vMove.x > 0 && !isFacingRight)
            {
                Flip(); 
            }
            else if (vMove.x < 0 && isFacingRight)
            {
                Flip(); 
            }
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight; 
            transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void SetDefaultSpeed()
        {
            this.speed = speedDefault;
        }

        public void LockAxisRigidBody2D()
        {
            rgBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }

    }
}

