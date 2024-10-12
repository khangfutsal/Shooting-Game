using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ShootingGame
{
    public class EnemyChase : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        [SerializeField] private float speed;
        [SerializeField] private float angularSpeed;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void Explode()
        {

        }

        void Start()
        {
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
            navMeshAgent.speed = speed;
            navMeshAgent.angularSpeed= angularSpeed;
           
        }

        // Update is called once per frame

        public void ChaseToPlayer(GameObject target)
        {
            navMeshAgent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z));
            FlipBasedOnDirection();

        }


        private void FlipBasedOnDirection()
        {
            Vector3 moveDirection = navMeshAgent.velocity;

            if (moveDirection.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            else if (moveDirection.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, -0, 0);
            }
        }

        public void SetVelocityZero()
        {
            navMeshAgent.speed = 0f;
        }
    }
}

