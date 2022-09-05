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
    private void Update()
    {
        CheckCooldown();
    }

    private void CheckCooldown()
    {
        if (timeSinceLastShot < fireRate)
        {
            timeSinceLastShot += Time.deltaTime;
            isOnCooldown = true;
            return;
        }
        isOnCooldown = false;
    }

    public void Shoot()
    {
        if (isOnCooldown)
            return;

        Projectile projectile = GameObject.Instantiate(projectilePrefab,this.transform,true);
        projectile.IgnoreCollision(gameObject.layer);
        projectile.transform.position = projectileSpawnLocation.transform.position;
        timeSinceLastShot = 0;
    }
}
