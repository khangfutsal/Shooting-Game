using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace ShootingGame
{
    public class HealthBuff : BaseBuff  
    {
        [SerializeField] private Player player;

        [SerializeField] private float speed;

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void ApplyBuff()
        {
            base.ApplyBuff();
            player.playerHealth.IncreaseHealth();
        }

        public override void RemoveBuff()
        {
            Debug.Log("Remove health buff");
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0, speed, 0));
        }


    }
}

