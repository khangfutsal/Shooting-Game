using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class ShieldBuff : BaseBuff
    {
        private Player player;
        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public override void ApplyBuff()
        {
            base.ApplyBuff();
            player.ActiveShieldBuff();
        }

        public override void RemoveBuff()
        {
            player.RemoveShieldBuff();
        }

    }
}

