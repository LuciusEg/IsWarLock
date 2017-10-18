using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAbilityTrigger : MonoBehaviour {
    [HideInInspector] public Rigidbody defaultAbility;
    public Transform spawnPoint;
    [HideInInspector] public float defaultAbilityLaunchForce = 250f;

    private void Start()
    {
        spawnPoint = GetComponent<Transform>();
    }

    public void Launch()
    {
        Rigidbody cloneBullet = Instantiate(defaultAbility, spawnPoint.position, transform.rotation) as Rigidbody;

        cloneBullet.AddForce(spawnPoint.transform.forward * defaultAbilityLaunchForce);
    }
}
