using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDying : MonoBehaviour {

    [HideInInspector] public bool isDestroyed = false;
    private Rigidbody _currentBullet;

    private void OnDestroy()
    {
        Debug.Log("isDestroyed MAFAKA1" + _currentBullet.transform.position);
        isDestroyed = true;
    }

    
    public void CurrentOnDeathBulletBehaviour(Rigidbody currentBullet)
    {
        _currentBullet = currentBullet;
    }
}
