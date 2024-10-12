using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private WeaponSlotsUI weaponSlotUI;
        [SerializeField] private ShopUI shopUI;
        public ShopUI GetShopUI() => shopUI;
        public WeaponSlotsUI GetWeaponSlotUI() => weaponSlotUI;
    }
}

