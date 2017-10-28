using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/SecondAbility")]
public class SecondAbility : Ability
{
    public float projectileForce;
    public float projectileLifeTime;
    public Rigidbody projectile;
    public bool projectileRequiresTargeting = false;
    public GameObject projectileParticleEffect;


    private AbilityBehaviour _launcher;

    public override void Initialize(GameObject obj)
    {
        _launcher = obj.GetComponent<AbilityBehaviour>();
        _launcher.dAbility = projectile;
        _launcher.dALaunchForce = projectileForce;
        _launcher.dALifeTime = projectileLifeTime;
        _launcher.dARequiresTargeting = projectileRequiresTargeting;
        _launcher.dAParticleEffect = projectileParticleEffect;
    }

    public override void TriggerAbility()
    {
        _launcher.Launch();
    }

    public override void BeforeDying()
    {
        Debug.Log("beforeDying message");
    }
}
