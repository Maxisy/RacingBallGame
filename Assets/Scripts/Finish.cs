using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Sphere") return;

        var gameController = FindObjectOfType<GameController>();
        gameController.CheckIfEndOfGame();
    }
}
