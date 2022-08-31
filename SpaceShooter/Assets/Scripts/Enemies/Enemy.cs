using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageDealer
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.GetScreenBounds2D();
    }
    
    private void OnEnable()
    {
        rb.velocity = new Vector2(-speed,0);    
    }

    private void Update()
    {
        if (transform.position.x < -screenBounds.x)
            Destroy(gameObject);    
    }

    public void DealDamage(IDamageable damageable)
    {
        int damageOnCollision = 1;
        damageable.TakeDamage(damageOnCollision);
    }
}
