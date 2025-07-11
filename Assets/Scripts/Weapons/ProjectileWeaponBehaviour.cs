using UnityEngine;

/// <summary>
/// Base script of all projectile behaviours
/// </summary>

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    protected float speed;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void Initialize(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }
   
}
