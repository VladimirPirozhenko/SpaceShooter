using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileSpawnLocation;
    [SerializeField] private int totalAmmo;
    [SerializeField] private float fireRate;
    [SerializeField] private LayerMask collisionToIgore;
    private float timeSinceLastShot;

    private int currentAmmo;
    private bool isOnCooldown = false;
    private void Start()
    {
         timeSinceLastShot = fireRate;
    }

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;
        while (isOnCooldown)
        {
            yield return new WaitForSeconds(fireRate);
            isOnCooldown = false;  
        }
    }

    public void Shoot()
    {
        if (isOnCooldown)
            return;

        Projectile projectile = GameObject.Instantiate(projectilePrefab,this.transform,false);
        //Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        projectile.IgnoreCollision(GetComponent<Collider2D>());  
        projectile.transform.position = projectileSpawnLocation.transform.position;
        projectile.transform.SetParent(null);
        projectile.gameObject.SetActive(true);  
        projectile.MoveInDirection(transform.right);
        timeSinceLastShot = 0;

        StartCoroutine(CooldownRoutine());
    }
}
