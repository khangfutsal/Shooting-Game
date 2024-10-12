using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace ShootingGame
{
    public class EnemyHealth : MonoBehaviour, ITakeDamage
    {
        private Coroutine coroutine;
        private SpriteRenderer spriteRenderer;
        [field :SerializeField] public float currentHealth { get; set; }
        [field :SerializeField] public float maxHealth { get; set; }

        public UnityEvent onDeath = new UnityEvent();
        public BoxCollider2D boxCollider2D;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            currentHealth = maxHealth;
            onDeath.AddListener(InActiveComponent);
        }


        public void TakeDamage(float health)
        {
            currentHealth -= health;
            if (currentHealth <= 0)
            {
                onDeath?.Invoke();
                Invoke(nameof(InActiveObject), 5f);
                return;
            }
            if (coroutine == null)
            {
                coroutine = StartCoroutine(DeathEffect());
            }
        }


        public IEnumerator DeathEffect()
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
            coroutine = null;
        }

        public void InActiveComponent()
        {
            boxCollider2D.enabled = false;
        }

        public void InActiveObject()
        {
            this.gameObject.SetActive(false);
        }
        
    }
}

