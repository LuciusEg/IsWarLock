using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDying : MonoBehaviour {

    [HideInInspector] public bool isDestroyed = false;

    private void OnDestroy()
    {
        Debug.Log("isDestroyed MAFAKA");
        isDestroyed = true;
    }
}
