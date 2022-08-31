using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamageable 
{
    public void TakeDamage(float amount);
    public event Action OnOutOfHealth;
}
