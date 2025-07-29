using UnityEngine;

public class EnemyShooter : EnemyBase
{
    public float shootCooldown = 2f;
    private float currentCooldown = 0;
    public GameObject arrowPrefab;

    protected override void Update()
    {
        base.Update();
        shootCooldown -= Time.deltaTime;

        if (shootCooldown <= 0f)
        {
            Shoot();
            currentCooldown = shootCooldown;
        }
    }

    void Shoot()
    {
        //spawn arrow
    }
}
