using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
namespace ShootingGame
{
    public class Enemy : MonoBehaviour
    {
        private GameObject playerTarget;
        #region Enemy Component
        public EnemyChase enemyChase;
        public EnemyAnimator enemyAnimator;
        public EnemyHealth enemyHealth;
        #endregion

        public bool isDeath;

        #region Unity Component

        #endregion
        private void Awake()
        {
            playerTarget = GameObject.Find("Player");
            enemyChase = GetComponent<EnemyChase>();
            enemyAnimator = GetComponent<EnemyAnimator>();
            enemyHealth = GetComponent<EnemyHealth>();
        }

        private void Start()
        {
            enemyHealth.onDeath.AddListener(Death);
        }

        private void Update()
        {
            
            HandleFunctionUpdate();
        }

        private void FixedUpdate()
        {
           
            HandleFunctionFixedUpdate();
        }

        public void HandleFunctionUpdate()
        {
            if (isDeath)
            {
                enemyChase.SetVelocityZero();
                return;
            }
            EnemyChaseFunction();
        }

        public void HandleFunctionFixedUpdate()
        {
            if (isDeath)
            {
                enemyChase.SetVelocityZero();
                return;
            }
        }

        #region Enemy Chase Function
        public void EnemyChaseFunction()
        {
            enemyChase.ChaseToPlayer(playerTarget);
            enemyAnimator.MoveAnimation();
        }
        #endregion

        #region Enemy Health Function

        public void Death()
        {
            isDeath = true;
            enemyAnimator.DeathAnimation();
        }

        #endregion

    }

}
