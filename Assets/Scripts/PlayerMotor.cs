using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    private NavMeshAgent _agent;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToPoint(Vector3 point)
    {
        //OnDrawGizmosSelected();
        _agent.SetDestination(point);
    }

    void OnDrawGizmosSelected()
    {
        var nav = GetComponent<NavMeshAgent>();
        if (nav == null || nav.path == null)
            return;

       
        //if (line == null)
        //{
        //    line = this.gameObject.AddComponent<LineRenderer>();
        //    line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.red };
        //    line.SetWidth(0.1f, 0.1f);
        //    line.SetColors(Color.blue, Color.black);
        //}

        //var path = nav.path;

        //var line = this.GetComponent<LineRenderer>();
        //line.positionCount = path.corners.Length;

        //for (int i = 0; i < path.corners.Length; i++)
        //{
        //    line.SetPosition(i, path.corners[i]);
        //}

    }
}


