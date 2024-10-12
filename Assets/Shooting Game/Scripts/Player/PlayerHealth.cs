using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class PlayerHealth : MonoBehaviour, ITakeDamage
    {
        [field: SerializeField] public float currentHealth { get; set; }
        [field: SerializeField] public float maxHealth { get; set; }

        public float healthBuff;

        public void TakeDamage(float health)
        {
        }

        public void IncreaseHealth()
        {
            Debug.Log("Health");
            currentHealth = Mathf.Clamp(currentHealth + healthBuff, 0, maxHealth);
        }


    }
}

