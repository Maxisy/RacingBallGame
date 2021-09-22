using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        transform.rotation = Quaternion.Euler(45, Time.timeSinceLevelLoad * 60, 45);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Sphere")
            return;

        Destroy(gameObject);
    }

}
