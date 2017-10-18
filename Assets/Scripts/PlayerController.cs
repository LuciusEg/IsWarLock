using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask _movementMask;
    private Camera _camera;
    private PlayerMotor _motor;
    //float yRotationLimit = 20f;

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

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, _movementMask))
            {
                //instant change look direction (fix y-axis pidarasilki))0))0
                //transform.rotation = Quaternion.LookRotation(new Vector3(hit.point.x, 0, hit.point.z) - new Vector3(transform.position.x, 0, transform.position.z));
                _motor.MoveToPoint(hit.point);
            }
        }
    }
}