using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{


    void Update()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            direction += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            direction += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction / 2);
    }
}
