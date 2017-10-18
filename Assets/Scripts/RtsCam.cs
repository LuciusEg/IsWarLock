using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsCam : MonoBehaviour {

    float _scrollSpeed = 20f;
    public float topBarrier;
    public float botBarrier;
    public float leftBarrier;
    public float rightBarrier;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.mousePosition.y >= Screen.height * topBarrier)
        {
            transform.Translate(Vector3.up * Time.deltaTime * _scrollSpeed, Space.World);
        }
        if (Input.mousePosition.y <= Screen.height * botBarrier)
        {
            transform.Translate(Vector3.down * Time.deltaTime * _scrollSpeed, Space.World);
        }
        if (Input.mousePosition.y >= Screen.width * rightBarrier)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _scrollSpeed, Space.World);
        }
        if (Input.mousePosition.y <= Screen.width * leftBarrier)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _scrollSpeed, Space.World);
        }
    }
}
