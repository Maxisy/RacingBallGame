using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    public Text CrystalCounterText;


    void Start()
    {
        UpdateCrystalCounterText();
    }

    void Update()
    {

    }

    public void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>();

        var crystalCount = crystals.Length;
        var crystalsInactive = crystals.Count(crystal => !crystal.Active);

        var text = crystalsInactive + " / " + crystalCount;
        CrystalCounterText.text = text;
    }
}
