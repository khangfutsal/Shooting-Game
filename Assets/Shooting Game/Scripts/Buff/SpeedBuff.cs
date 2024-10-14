using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class SpeedBuff : BaseBuff
    {
        private Player player;
        [SerializeField] private float inspireSpeed;
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
        public override void ApplyBuff()
        {
            base.ApplyBuff();
            player.playerMove.SetSpeed(inspireSpeed);
            var speedBuff = UIController.Ins.manager.GetGamePlayUI().buffUI.GetCurBuff("Speed");
            speedBuff.time = buffSO.buffData.effectTime;
            speedBuff.Show();
        }

        public override void RemoveBuff()
        {
            player.playerMove.SetDefaultSpeed();
            var speedBuff = UIController.Ins.manager.GetGamePlayUI().buffUI.GetCurBuff("Speed");
            speedBuff.Hide();
        }


    }
}

