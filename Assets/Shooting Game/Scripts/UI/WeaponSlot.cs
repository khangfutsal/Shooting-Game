using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class WeaponSlot : MonoBehaviour
    {
        public WeaponSlotData weaponSlotData;

        private void Start()
        {
            if(!weaponSlotData.isUnlock)
            {
                ShowUnlockImage();
                HideGunImage();
            }
        }


        public bool GetUnlockWeapon
        {
            get { return weaponSlotData.isUnlock; }
            set
            {
                weaponSlotData.isUnlock = value;
            }
        }

        public bool GetUsingWeapon
        {
            get { return weaponSlotData.isUsing; }
            set
            {
                weaponSlotData.isUsing = value;
            }
        }

        public void ShowUnlockImage()
        {
            weaponSlotData.lockImage.gameObject.SetActive(true);
        }

        public void HideUnlockImage()
        {
            weaponSlotData.lockImage.gameObject.SetActive(false);
        }

        public void ShowUsingImage()
        {
            weaponSlotData.usingImage.gameObject.SetActive(true);
        }

        public void HideUsingImage()
        {
            weaponSlotData.usingImage.gameObject.SetActive(false);
        }

        public void ShowGunImage()
        {
            weaponSlotData.GunImage.gameObject.SetActive(true);
        }

        public void HideGunImage()
        {
            weaponSlotData.GunImage.gameObject.SetActive(false);
        }

        public void UpdateTextAmmo(int ammo)
        {
            weaponSlotData.textAmmo.text = ammo.ToString();
        }




    }
}


