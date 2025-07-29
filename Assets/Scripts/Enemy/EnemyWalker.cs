using UnityEngine;

public class EnemyWalker : EnemyBase
{
    public float speed = 2f;

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
