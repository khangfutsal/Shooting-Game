using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    [Serializable]
    public class ItemData
    {
        public ItemType itemType;
        public Sprite sprite;
        public int goldAmount;
        public bool isBought;
    }


}
