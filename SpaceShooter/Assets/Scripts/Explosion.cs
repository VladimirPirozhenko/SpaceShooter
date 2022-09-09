using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;

    private int explodeHash = Animator.StringToHash("Explosion1Anim");
    bool isFinished = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        AnimatorStateInfo animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationTime = animStateInfo.normalizedTime;
        if (animationTime > 1.0f)
        {
            isFinished = true;
        }
        if (isFinished)
            gameObject.SetActive(false);
    }
    public void PlayExplosionAnimaton()
    {
        gameObject.SetActive(true);
        animator.Play(explodeHash); 
    }
}
