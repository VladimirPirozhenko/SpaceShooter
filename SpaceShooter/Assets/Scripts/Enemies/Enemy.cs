using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour,IDamageDealer
{
    [SerializeField] private float speed;

    private Explosion explosionOnDeath;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Health health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = new Vector2(-speed,0);    
        health = GetComponent<Health>();
        screenBounds = Camera.main.GetScreenBounds2D();
        explosionOnDeath = gameObject.GetComponentInChildren<Explosion>();
     //   explosionOnDeath = Instantiate(explosionOnDeath);
        //explosionOnDeath.transform.SetParent(transform,true);
    }
    
    private void OnEnable()
    {   
        health.OnOutOfHealth += Die;
    }

    private void OnDisable()
    {
        health.OnOutOfHealth -= Die;
    }
    
    protected virtual void Update()
    {
         HandleOutOfBounds();
         Debug.Log("ENEMY VELOCITY: " + rb.velocity.ToString());
    }

    private void HandleOutOfBounds()
    {
        if (transform.position.x < -screenBounds.x)
            Destroy(gameObject);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageDealer damageDealer))
        {
            damageDealer.DealDamage(health);
        }
    }

    public void DealDamage(IDamageable damageable)
    {
        int damageOnCollision = 1;
        damageable.TakeDamage(damageOnCollision);
    }

    public void Die()
    {
        explosionOnDeath.gameObject.SetActive(true);
        explosionOnDeath.transform.SetParent(null);
        explosionOnDeath.PlayExplosionAnimaton();   
        gameObject.SetActive(false);     
    }
}
