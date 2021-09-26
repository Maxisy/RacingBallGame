using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonCheckpointBefore : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere")
        {
            var camera = FindObjectOfType<Camera>();
            var sphere = FindObjectOfType<Sphere>();

            camera.PassedCheckpoint = true;
            sphere.PassedCheckpoint = true;
        }
    }
}
