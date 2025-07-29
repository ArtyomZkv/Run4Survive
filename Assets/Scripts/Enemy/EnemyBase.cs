using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float health;
    public Transform target;
    
    void Start()
    {
        target = FindFirstObjectByType<PlayerMovement>().transform;
    }

    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {

    }
    public void TakeDamage(float amount)
    {
        health = -amount;
        if(health <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
