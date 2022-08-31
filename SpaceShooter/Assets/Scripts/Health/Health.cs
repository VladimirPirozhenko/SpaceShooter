using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour,IDamageable,IHealable
{
    public event Action OnOutOfHealth;
    public event Action<float,float> OnHealthChanged;

    [field: SerializeField] public float MaxHealth  { get; private set; }
    [field: SerializeField] public float CurrentHealth { get; private set; }

    private void Start()
    {
        OnHealthChanged?.Invoke(CurrentHealth,MaxHealth);
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        OnHealthChanged?.Invoke(CurrentHealth,MaxHealth);
        if (CurrentHealth < 1)
        {
            OnOutOfHealth?.Invoke();
        }
    }
    public void Heal(float amount)
    {
        if (CurrentHealth < MaxHealth)
            CurrentHealth += amount;
        OnHealthChanged?.Invoke(CurrentHealth,MaxHealth);
    }

    public void IncreaseMaxHealth(float amount)
    {
        MaxHealth += amount;
        OnHealthChanged?.Invoke(CurrentHealth,MaxHealth);
    }
}
