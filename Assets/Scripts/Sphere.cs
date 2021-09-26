using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public bool CanMove = false;
    public bool PassedCheckpoint = false;

    void Update()
    {
        if (!CanMove) return;

        var direction = Vector3.zero;

        if (!PassedCheckpoint)
        {

            if (Input.GetKey(KeyCode.W))
                direction += Vector3.forward;

            if (Input.GetKey(KeyCode.S))
                direction += Vector3.back;

            if (Input.GetKey(KeyCode.A))
                direction += Vector3.left;

            if (Input.GetKey(KeyCode.D))
                direction += Vector3.right;

        } 
        else
        {
            if (Input.GetKey(KeyCode.W))
                direction += Vector3.left;

            if (Input.GetKey(KeyCode.S))
                direction += Vector3.right;

            if (Input.GetKey(KeyCode.A))
                direction += Vector3.back;

            if (Input.GetKey(KeyCode.D))
                direction += Vector3.forward;
        }

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction * (Time.deltaTime * 500));
    }
}
