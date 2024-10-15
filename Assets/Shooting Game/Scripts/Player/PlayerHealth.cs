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

        [SerializeField] private SpriteRenderer HeadSprite;
        [SerializeField] private SpriteRenderer BodySprite;
        [SerializeField] private SpriteRenderer ArmSprite;
        private Coroutine coroutine;

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
            if (coroutine == null)
            {
                coroutine = StartCoroutine(TakeDamageEffect());
            }
        }

        public IEnumerator TakeDamageEffect()
        {
            HeadSprite.color = Color.red;
            ArmSprite.color = Color.red;
            BodySprite.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            HeadSprite.color = Color.white;
            ArmSprite.color = Color.white;
            BodySprite.color = Color.white;

            coroutine = null;
        }

        public void IncreaseHealth()
        {
            currentHealth = Mathf.Clamp(currentHealth + healthBuff, 0, maxHealth);
            UIController.Ins.manager.GetGamePlayUI().healthUI.ChangeSlider(currentHealth);
        }


    }
}

