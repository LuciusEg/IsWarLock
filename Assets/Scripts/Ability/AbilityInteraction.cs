using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInteraction : MonoBehaviour
{
    [Header("Hi there!")]
    public GameObject shell;
    public Transform shellLaunchPlace;
    public float shellLaunchHeight = 2.1f;
    //public Transform shell_targetPoint;
    [Space(10)]
    public float shellSpeed = 1f;
    public float shellLifeTime = 1f;
    public float shellBlastRadius = 1f;

    public float abilityCooldown;
    float _nextShell;
    bool _isSpellButtonPressed = false;
    public LayerMask _movementMask;

    private ShellBehaviour _shellBehaviour;
    private Camera _camera;

    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
        _shellBehaviour = GetComponent<ShellBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        defaultShell();
    }

    public void defaultShell()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextShell)
        {
            _isSpellButtonPressed = true;
        }
        if (Input.GetMouseButton(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, _movementMask))
            {
                if (_isSpellButtonPressed == true)
                {
                    if (Time.time > _nextShell)
                    {
                        _shellBehaviour.launchNewShell(shell, shellLaunchPlace, hit.point, shellSpeed);
                        _nextShell = Time.time + abilityCooldown;
                        _isSpellButtonPressed = false;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            _isSpellButtonPressed = false;
        }
    }
}