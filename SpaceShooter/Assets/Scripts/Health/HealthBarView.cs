using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
        [SerializeField] private Image healthBar;
        [SerializeField] private Health health;

        [SerializeField] private float healthChangingSpeed;
        private float cachedFillAmount;
        private float accumulation;
        private void Start()
        {
            cachedFillAmount = healthBar.fillAmount;
            ChangeColor();
        }
        private void Update()
        {
            ChangeHealthValue();
        }
        public void ChangeHealthValue()
        { 
            float healthPercentage = health.CurrentHealth/health.MaxHealth;
            if (healthPercentage != cachedFillAmount)
            {
                accumulation += healthChangingSpeed * Time.deltaTime;
                healthBar.fillAmount = Mathf.Lerp(healthPercentage,healthPercentage,accumulation);
                ChangeColor();
               // Debug.Log("FILLAMOUNT = " + healthBar.fillAmount);
               // Debug.Log("healthPercentage = " + healthPercentage);
                return;
            }
            accumulation = 0;
            cachedFillAmount = healthBar.fillAmount;
        }

        public void ChangeColor()
        {
            Color healthColor = Color.Lerp(Color.red,Color.green,(health.CurrentHealth/health.MaxHealth));
            healthBar.color = healthColor;
        }  
}
