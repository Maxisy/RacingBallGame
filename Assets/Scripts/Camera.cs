using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 delta;
    public Transform ObjectToTrack;


    void FixedUpdate()
    {
        transform.LookAt(ObjectToTrack);

        var trackedRigidbody = ObjectToTrack.GetComponent<Rigidbody>();
        var ballSpeed = trackedRigidbody.velocity.magnitude;

        var targetPosition = ObjectToTrack.position + delta * (ballSpeed / 20 + 1f);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.smoothDeltaTime * 2f);
    }
}
