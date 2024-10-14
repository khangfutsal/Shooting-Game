using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace ShootingGame
{
    public class GamePlayUI : MonoBehaviour
    {
        public WeaponSlotsUI weaponSlotsUI;
        public HealthUI healthUI;
        public BuffUI buffUI;

        public GameObject reloadingText;
        public TextMeshProUGUI timeText;

        private void Start()
        {
            HideReloadingText();
        }

        public void ShowReloadingText()
        {
            reloadingText.SetActive(true);
        }

        public void HideReloadingText()
        {
            reloadingText.SetActive(false);
        }

        public void UpdateTimeUI(float elapsedTime)
        {
            elapsedTime += Time.deltaTime; 

            TimeSpan time = TimeSpan.FromSeconds(elapsedTime);
            string timeString = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);

            timeText.text = timeString;
        }


    }
}

