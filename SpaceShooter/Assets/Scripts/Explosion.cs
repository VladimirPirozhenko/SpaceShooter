using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;

    private int explodeHash = Animator.StringToHash("Explosion1Anim");
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    public void PlayExplosionAnimaton()
    {
        animator.Play("Explosion1Anim");
    }
}
