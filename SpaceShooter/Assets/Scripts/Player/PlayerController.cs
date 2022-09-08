using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour,IShooter
{ 
    [SerializeField] private float speed;
    [SerializeField] private float smoothTime;
    private Weapon weapon;
    
    private IPlayerInput playerInput; 
    private Rigidbody2D rb;
    private Health health;

    private Transform playerTransform;
    private Camera mainCamera;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        weapon = GetComponent<Weapon>();
        mainCamera = Camera.main;
        playerInput = new KeyPlayerInput();
    }
    private void Update()
    {
        Move();
        KeepInCameraView();
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageDealer damageDealer))
        {
            damageDealer.DealDamage(health);
        }
    }

    //INSERT HERE ALL TYPES OF MOVEMENT
    public void Move()
    {
        Vector2 movementDirection = playerInput.ReadMovement();
        Vector3 targetVelocity = movementDirection * speed;
        Vector3 velocity = Vector3.zero;
        transform.Translate(targetVelocity * Time.deltaTime);
       // rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity,smoothTime);
    }

    public void Shoot()
    {
        if (!weapon)
            return;
        bool canShoot = playerInput.ReadShootInput();
        if (canShoot) weapon.Shoot();
    }

    public void KeepInCameraView()
    {
        Vector3 posInViewport = mainCamera.WorldToViewportPoint(playerTransform.position);
        posInViewport.x = Mathf.Clamp01(posInViewport.x);
        posInViewport.y = Mathf.Clamp01(posInViewport.y);
        transform.position = mainCamera.ViewportToWorldPoint(posInViewport);
    }
}
