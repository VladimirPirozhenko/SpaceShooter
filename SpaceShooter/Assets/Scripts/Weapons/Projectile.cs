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
    
    private void OnEnable()
    {
       // rb.velocity = new Vector2(speed,0);    
    }
    private void Start()
    {
        Destroy(this.gameObject,3);
        transform.SetParent(null);
    }
    public void MoveInDirection(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    public void IgnoreCollision(int collisionLayer)
    {
        collisionToIgore = collisionLayer;
        Physics2D.IgnoreLayerCollision(collisionLayer,gameObject.layer,true);
    }

    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
