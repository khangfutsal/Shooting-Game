using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    [Serializable]
    public class WeaponSlotData
    {
        public int id;
        public bool isUnlock;
        public bool isUsing;
        public Image lockImage;
        public Image usingImage;
        public Image GunImage;
        public TextMeshProUGUI textAmmo;
    }
}

