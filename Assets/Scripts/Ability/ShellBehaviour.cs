using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{

    private GameObject _currentShell;
    private Transform _launchPlace;
    private Vector3 _launchPoint;
    private Vector3 _targetPos;
    private float _speed;

    private GameObject _currentShellInstantiated;

    // Update is called once per frame
    void Update()
    {
        if (_currentShellInstantiated)
        {
            _currentShellInstantiated.transform.position = Vector3.MoveTowards(_currentShellInstantiated.transform.position, new Vector3(_targetPos.x, 2.6f,_targetPos.z), _speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Create and launch shell
    /// </summary>
    /// <param name="currentShell"></param>
    /// <param name="shell spawn point"></param>
    /// <param name="shell target"></param>
    /// <param name="shell speed"></param>
    public void launchNewShell(GameObject currentShell, Transform launchPlace, Vector3 targetPosition, float speed)
    {
        _currentShell = currentShell;
        _launchPlace = launchPlace;
        _targetPos = targetPosition;
        _speed = speed;

        _currentShellInstantiated = Instantiate(
            _currentShell,
            _launchPlace.position,
            _launchPlace.rotation);
    }
}
