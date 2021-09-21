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

        var targetPosition =  ObjectToTrack.position + delta;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.smoothDeltaTime * 2f);
    }
}
