using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask collisionToIgore;
    private Rigidbody2D rb;
    private Collider2D col;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        Destroy(this.gameObject,3);
        transform.SetParent(null);
    }

    private void Update()
    {
        Debug.Log("ProjectileVelocity:" + rb.velocity.ToString());
    }

    public void MoveInDirection(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    
    }

    public void IgnoreCollision(Collider2D colliderToIgnore)
    {
        Physics2D.IgnoreCollision(colliderToIgnore, GetComponent<Collider2D>(),true);
    }

    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
