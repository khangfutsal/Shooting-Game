using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public interface ITakeDamage
    {
        public float currentHealth { get; set; }
        public float maxHealth { get; set; }
        public void TakeDamage(float health);

    }

    public interface IShopCustomer
    {
        public void BoughtItem(ItemType item);
        public bool TrySpendGoldAmount(int goldAmount);
    }
    
}

