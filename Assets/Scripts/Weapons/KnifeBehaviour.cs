using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    KnifeController kc;

    protected override void Start()
    {
        base.Start();
        DirectionChecker();
    }
    void Update()
    {
        transform.position += speed * Time.deltaTime * direction; //Set the movement of the knife
    }
}
