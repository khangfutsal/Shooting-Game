using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShootingGame
{
    public class PlayerHealth : MonoBehaviour, ITakeDamage
    {
        [field: SerializeField] public float currentHealth { get; set; }
        [field: SerializeField] public float maxHealth { get; set; }
        public UnityEvent onDeath = new UnityEvent();
        public float healthBuff;

        private void Start()
        {
            currentHealth = maxHealth;
            UIController.Ins.manager.GetGamePlayUI().healthUI.Initialize(maxHealth);
        }

        public void TakeDamage(float health)
        {
            currentHealth = Mathf.Clamp(currentHealth - health, 0, maxHealth);
            UIController.Ins.manager.GetGamePlayUI().healthUI.ChangeSlider(currentHealth);

            if (currentHealth <= 0)
            {
                onDeath.Invoke();
            }
        }

        public void IncreaseHealth()
        {
            currentHealth = Mathf.Clamp(currentHealth + healthBuff, 0, maxHealth);
            UIController.Ins.manager.GetGamePlayUI().healthUI.ChangeSlider(currentHealth);
        }


    }
}

