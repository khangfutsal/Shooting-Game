using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int gold;
        public int GetCurrentGold() => gold;
        
        public void AdditiveGold(int gold)
        {
            this.gold += gold;
        }

        public void MinusGold(int gold)
        {
            this.gold -= gold;
        }

    }
}

