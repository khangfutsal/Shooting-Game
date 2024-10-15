using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Camera camera;

        private void Awake()
        {
        }

        private void Update()
        {
            var target = player.position;
            target.z = -10;
            camera.transform.position = target;
        }
    }
}

