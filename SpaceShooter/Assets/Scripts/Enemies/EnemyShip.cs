using UnityEngine;
public class EnemyShip : Enemy, IShooter
{
    private Weapon weapon;
    
    private void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    protected override void Update()
    {
        base.Update();
        Shoot();
    }

    public void Shoot()
    {
       weapon.Shoot();
    }   
}
