using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public bool Active = true;

    void Update()
    {
        transform.rotation = Quaternion.Euler(45, Time.timeSinceLevelLoad * 60, 45);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Active) return;
        if (other.name != "Sphere") return;

        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        Active = false;

        var gameController = FindObjectOfType<GameController>();
        gameController.UpdateCrystalCounterText();
    }

}
