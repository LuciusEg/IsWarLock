using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventScript : MonoBehaviour {
    public AbilityInteraction abilityIteraction;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //abilityIteraction.defaultShell();
    }

    public void PressedButton_Spell1()
    {
        Debug.Log("Yep!");
        
    }
}
