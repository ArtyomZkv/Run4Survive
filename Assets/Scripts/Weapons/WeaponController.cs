using Unity.Hierarchy;
using UnityEngine;

/// <summary>
/// Base script for all weapons
/// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    protected PlayerMovement pm;

    protected virtual void Start()
    {
        pm = FindFirstObjectByType<PlayerMovement>();
        currentCooldown = cooldownDuration; // At the start set the current cooldown to be the cooldown duration
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();
        }
    }

   protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
