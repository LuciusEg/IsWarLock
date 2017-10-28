using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string aName = "New Ability";
    public string aDescription = "default description";
    public Sprite aIcon;
    public float aBaseCoolDown;

    //[Space(50)]
    //[Header("Main characteristics")]


    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();

    public abstract void BeforeDying();
}