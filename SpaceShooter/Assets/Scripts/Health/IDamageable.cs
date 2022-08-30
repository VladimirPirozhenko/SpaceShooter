using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamageable 
{
    public void TakeDamage(int amount);
    public event Action OnOutOfHealth;
}
