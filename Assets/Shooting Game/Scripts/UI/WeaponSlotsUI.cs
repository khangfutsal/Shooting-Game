using ShootingGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotsUI : MonoBehaviour
{
    [SerializeField] private List<WeaponSlot> weaponSlots;

    public List<WeaponSlot> GetWeaponSlots() => weaponSlots;

    public WeaponSlot GetWeaponSlot(int id)
    {
        Debug.Log("Test : " + id);
        return weaponSlots.Find(_ => _.weaponSlotData.id == id);
    }

}
