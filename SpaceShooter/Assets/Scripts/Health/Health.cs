using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour,IDamageable,IHealable
{
    public event Action OnOutOfHealth;
    public event Action<int,int> OnHealthChanged;
    private int MaxHealth;
    private int CurrentHealth;
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        OnHealthChanged?.Invoke(CurrentHealth,MaxHealth);
        if (CurrentHealth < 1)
        {
            OnOutOfHealth?.Invoke();
        }
    }
    public void Heal(int amount)
    {
        if (CurrentHealth < MaxHealth)
            CurrentHealth += amount;
        OnHealthChanged?.Invoke(CurrentHealth,MaxHealth);
    }
}
