using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text CrystalCounterText;
    public Text CountdownText;
    public Text GameEndText;

    public AudioClip GameWinSound;
    public AudioClip GameLoseSound;

    public int level;

    void Start()
    {
        Cursor.visible = false;

        UpdateCrystalCounterText();
        StartCoroutine(CountdownCoroutine());

        GameEndText.enabled = false;

        level = FindObjectOfType<SceneName>().GetLevel();

        Cursor.visible = false;
    }

    IEnumerator CountdownCoroutine()
    {
        var sphere = FindObjectOfType<Sphere>();
        sphere.CanMove = false;

        CountdownText.enabled = true;

        for (int i = 3; i > 0; i--)
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        CountdownText.text = "START!";
        sphere.CanMove = true;
        yield return new WaitForSeconds(1);

        CountdownText.enabled = false;
    }

    public void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>();

        var crystalCount = crystals.Length;
        var crystalsInactive = crystals.Count(crystal => !crystal.Active);

        var text = crystalsInactive + " / " + crystalCount;
        CrystalCounterText.text = text;
    }

    public void CheckIfEndOfGame()
    {
        var endOfGame = FindObjectsOfType<Crystal>().All(crystal => !crystal.Active);

        if (!endOfGame) return;

        EndOfGame(true);
    }

    public void EndOfGame(bool win)
    {
        level++;
        StartCoroutine(EndOfGameCoroutine(win));
    }

    IEnumerator EndOfGameCoroutine(bool win)
    {
        GameEndText.text = win ? "WYGRANA!" : "PRZEGRANA";
        GameEndText.enabled = true;
        var sphere = FindObjectOfType<Sphere>();
        sphere.CanMove = false;
        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;

        FindObjectOfType<GameMusic>().FadeOut(2, 0);

        yield return new WaitForSeconds(2);

        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = win ? GameWinSound : GameLoseSound;
        audioSource.Play();

        yield return new WaitForSeconds(5);


        if (win)
        {
            if (level == 3)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("" + level + "");
            }
        }
        else
        {
            Application.Quit();
        }

        

        
    }
}
