using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask _movementMask;
    private Camera _camera;
    private PlayerMotor _motor;
    private bool _isRotationEnded = true;

    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
        _motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (_isRotationEnded) 
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, _movementMask))
                {
                    _motor.MoveToPoint(hit.point);
                }
            }
        }
    }
}