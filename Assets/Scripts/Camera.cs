using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 delta;
    public Transform ObjectToTrack;
    public bool PassedCheckpoint = false;


    void FixedUpdate()
    {
    
        transform.LookAt(ObjectToTrack);

        var trackedRigidbody = ObjectToTrack.GetComponent<Rigidbody>();
        var ballSpeed = trackedRigidbody.velocity.magnitude;

        if (!PassedCheckpoint)
        {

            var targetPosition = ObjectToTrack.position + delta * (ballSpeed / 20 + 1f);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.smoothDeltaTime * 2f);
        }
        else
        {
            Vector3 pylonDelta = new Vector3(0, 11.3f, 0);

            var targetPosition = ObjectToTrack.position + pylonDelta * (ballSpeed / 20 + 1f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.smoothDeltaTime * 2f);
        }
    }
}
