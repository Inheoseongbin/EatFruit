using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Vector3[] _sixdir = { Vector3.forward, Vector3.back, Vector3.up, Vector3.down, Vector3.left, Vector3.right };
    public LayerMask Floor;
    private float _raydistance = 1;

    void Update()
    {
        Dicecheck();
    }

    private void Dicecheck()
    {
        Ray forward = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(forward, out hit, _raydistance, Floor))
        {
            Debug.Log(6);
        }
        if (Physics.Raycast(transform.position, transform.forward * -1, out hit, _raydistance, Floor))
        {
            Debug.Log(1);
        }
        if (Physics.Raycast(transform.position, transform.right, out hit, _raydistance, Floor))
        {
            Debug.Log(3);
        }
        if (Physics.Raycast(transform.position, transform.right * -1, out hit, _raydistance, Floor))
        {
            Debug.Log(4);
        }
        if (Physics.Raycast(transform.position, transform.up, out hit, _raydistance, Floor))
        {
            Debug.Log(5);
        }
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, _raydistance, Floor))
        {
            Debug.Log(2);
        }

    }
}
