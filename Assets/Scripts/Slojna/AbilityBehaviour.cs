using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehaviour : MonoBehaviour
{
    [HideInInspector] public Rigidbody dAbility;
    [HideInInspector] public float dALaunchForce;
    [HideInInspector] public float dALifeTime;
    [HideInInspector] public bool dARequiresTargeting;
    [HideInInspector] public GameObject dAParticleEffect;

    public Transform spawnPoint;
    private Rigidbody _cloneBullet;

    private OnDying _deathSign;

    private void Start()
    {
        spawnPoint = GetComponent<Transform>();
    }



    public void Launch()
    {
        _cloneBullet = Instantiate(dAbility, spawnPoint.position, transform.rotation) as Rigidbody;

        _cloneBullet.AddForce(spawnPoint.transform.forward * dALaunchForce);

        Destroy(_cloneBullet.gameObject, dALifeTime);

        // ¯\_(ツ)_/¯¯\_(ツ)_/¯
        //_deathSign = _cloneBullet.GetComponentInParent<OnDying>();

        //работает дерьмово (убивает другие снаряды)
        //Invoke("ExplodeCloneBullet(_cloneBullet)", dALifeTime);
        //StartCoroutine(ExplodeCloneBullet(_cloneBullet, dALifeTime));
    }

    #region Dermovo rabotaet
    //IEnumerator ExplodeCloneBullet(Rigidbody thisClone, float delayTime)
    //{
    //    yield return new WaitForSeconds(delayTime);
    //    // Now do your thing here
    //    Debug.Log("whatsup");
    //    Destroy(_cloneBullet.gameObject);
    //}

    //private void ExplodeCloneBullet(Rigidbody thisClone)
    //{
    //    Debug.Log("whatsup");
    //    Destroy(thisClone.gameObject);
    //}
    #endregion

    #region Rabotaet norm, no rugaetsya ROFL
    private void Update()
    {
        //ЧИСТ ВАВАНА СПРАСИТЬ
        //не работает ¯\_(ツ)_/¯
        //if (_deathSign)
        //{
        //работает но ругается ¯\_(ツ)_/¯ ¯\_(ツ)_/¯
        //if (_deathSign.isDestroyed)
        //{
        //    Debug.Log("WAZAP!");
        //    _deathSign.isDestroyed = false;
        //}
        //}
    }
    #endregion
}
