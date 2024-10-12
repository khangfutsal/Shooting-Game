using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class EnemyAnimator : MonoBehaviour
    {
        public Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void MoveAnimation()
        {
            anim.SetBool("Death", false);
            anim.SetBool("Walk", true);
        }

        public void DeathAnimation()
        {
            anim.SetBool("Death", true);
            anim.SetBool("Walk", false);
        }
    }
}

