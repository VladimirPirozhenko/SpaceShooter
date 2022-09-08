using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour, IShooter
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileSpawnLocation;
    [SerializeField] private int totalAmmo;
    [SerializeField] private float fireRate;
    [SerializeField] private LayerMask collisionToIgore;

    private int currentAmmo;
    private bool isOnCooldown = false;

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
        projectile.IgnoreCollision(GetComponent<Collider2D>());  
        projectile.transform.position = projectileSpawnLocation.transform.position;
        projectile.transform.SetParent(null);
        projectile.gameObject.SetActive(true);  
        projectile.MoveInDirection(transform.right);

        StartCoroutine(CooldownRoutine());
    }
}
