using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsCam : MonoBehaviour
{
    public Transform target;
    public float scrollSpeed = 15f;
    public float scrollEdge = 0.1f;
    public float panSpeed = 10f;

    public Vector2 zoomRange = new Vector2(-5f, 5f);
    public float currentZoom = 0f;
    public float zoomSpeed = 1f;
    public float zoomRotation = 1f;

    public float onCameraFocusOffset_z = 6f;
    private bool isCameraFocused;

    private Vector3 _initPos;
    private Vector3 _initRotation;
    private Vector3 _newPosY;
    private Vector3 _newPosX;

    void Start()
    {
        _initPos = transform.position;
        _initRotation = transform.eulerAngles;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCameraFocused = !isCameraFocused;
        }

        if (isCameraFocused)
        {
            FocusOnPlayer();
        }
        else
        {
            ScrollCameraByMouse();
        }
        
        //incorrect
        //ZoomCameraByWhell();
    }

    private void FocusOnPlayer()
    {
        transform.position = new Vector3(target.position.x, _initPos.y, target.position.z - onCameraFocusOffset_z);
    }

    private void ScrollCameraByMouse()
    {
        if (Input.GetMouseButton(3))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * panSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);
        }
        else
        {
            if (Input.mousePosition.x >= Screen.width * (1 - scrollEdge) && Input.mousePosition.x <= Screen.width)
            {
                transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
            }
            else if (Input.mousePosition.x <= Screen.width * scrollEdge && Input.mousePosition.x >= 0)
            {
                transform.Translate(Vector3.right * Time.deltaTime * -scrollSpeed, Space.World);
            }

            if (Input.mousePosition.y >= Screen.height * (1 - scrollEdge) && Input.mousePosition.y <= Screen.height)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
            }
            else if (Input.mousePosition.y <= Screen.height * scrollEdge && Input.mousePosition.y <= 0)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -scrollSpeed, Space.World);
            }
        }
    }

    private void ZoomCameraByWhell()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * zoomSpeed;

        currentZoom = Mathf.Clamp(currentZoom, zoomRange.x, zoomRange.y);

        _newPosY -= new Vector3(
            transform.position.x
            , Convert.ToSingle((transform.position.y - (_initPos.y + currentZoom)) * 0.1)
            , transform.position.z);

        _newPosX -= new Vector3(
            Convert.ToSingle((transform.eulerAngles.x - (_initRotation.x + currentZoom * zoomRotation)) * 0.1)
            , transform.eulerAngles.y
            , transform.eulerAngles.z);

        transform.position = _newPosY;
        transform.eulerAngles = _newPosX;
    }
}