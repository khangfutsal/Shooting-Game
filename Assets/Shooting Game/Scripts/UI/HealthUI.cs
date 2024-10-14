using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGame
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        public void Initialize(float maxValue)
        {
            Debug.Log(maxValue);
            slider.maxValue = maxValue;
        }

        public void ChangeSlider(float value)
        {
            slider.value = value;

        }
    }
}

