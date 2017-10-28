using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCD : MonoBehaviour
{

    public string abilityButtonKey;
    public Image darkMask;
    public Text coolDownTextDisplay;

    [SerializeField] private Ability _ability;
    [SerializeField] private GameObject _weaponHolder;
    private Image _myButtonImage;
    //private AudioSource _abilitySource;
    private float _coolDownDuration;
    private float _nextReadyTime;
    private float _coolDownTimeLeft;
    //private Rigidbody _rBody;

    bool _isButtonTriggered;


    void Start()
    {
        Initialize(_ability, _weaponHolder);
    }

    public void Initialize(Ability selectedAbility, GameObject weaponHolder)
    {
        _ability = selectedAbility;
        _myButtonImage = GetComponent<Image>();
        //_abilitySource = GetComponent<AudioSource>();
        _myButtonImage.sprite = _ability.aIcon;
        darkMask.sprite = _ability.aIcon;
        _coolDownDuration = _ability.aBaseCoolDown;
        _ability.Initialize(_weaponHolder);
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time >= _nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetKeyDown(KeyCode.R))
            {
                ButtonTriggered();
            }

            if (_isButtonTriggered)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _ability.TriggerAbility();
                    AbilityTriggered();
                }
                if (Input.GetMouseButtonDown(1))
                {
                    discardButtonTriggered();
                    Debug.Log("discarded");
                }
            }
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        _coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(_coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = (_coolDownTimeLeft / _coolDownDuration);
    }

    private void ButtonTriggered()
    {
        _isButtonTriggered = true;
    }

    private void discardButtonTriggered()
    {
        _isButtonTriggered = false;
    }

    private void AbilityTriggered()
    {
            _nextReadyTime = _coolDownDuration + Time.time;
            _coolDownTimeLeft = _coolDownDuration;
            darkMask.enabled = true;
            coolDownTextDisplay.enabled = true;

            //abilitySource.clip = ability.aSound;
            //abilitySource.Play();
            _isButtonTriggered = false;        
    }
}