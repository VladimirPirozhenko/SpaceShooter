using UnityEngine;
public class EnemyShip : Enemy, IShooter
{
    // [SerializeField]  private Weapon weapon;
    private Weapon weapon;
    private void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
       weapon.Shoot();
    }   
}
