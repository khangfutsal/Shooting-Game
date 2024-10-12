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
        [SerializeField] private bool isFacingRight = true;

        private void Awake()
        {
            rgBody2D = GetComponent<Rigidbody2D>();
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

    }
}

