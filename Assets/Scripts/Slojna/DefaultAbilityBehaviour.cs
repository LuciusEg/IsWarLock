using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/DefaultAbilityBehaviour")]
public class DefaultAbilityBehaviour : Ability {
    public float projectileForce = 300f;
    public Rigidbody projectile;

    private DefaultAbilityTrigger launcher;

    public override void Initialize(GameObject obj)
    {
        launcher = obj.GetComponent<DefaultAbilityTrigger>();
        launcher.defaultAbilityLaunchForce = projectileForce;
        launcher.defaultAbility = projectile;
    }

    public override void TriggerAbility()
    {
        launcher.Launch();
    }
}
