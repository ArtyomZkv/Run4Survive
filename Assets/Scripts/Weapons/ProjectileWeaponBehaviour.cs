using System;
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
    public void DirectionChecker()
    {
        float baseAngleOffset = -45f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 scale = transform.localScale;

        transform.rotation = Quaternion.Euler(0f, 0f, angle + baseAngleOffset);
        transform.localScale = scale;
    }
}
