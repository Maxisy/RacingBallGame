using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{

    void Start()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void FadeOut(float duration, float targetVolume)
    {
        StartCoroutine(FadeOutCoroutine(duration, targetVolume));
    }

    public IEnumerator FadeOutCoroutine(float duration, float targetVolume)
    {
        var audioSource = GetComponent<AudioSource>();
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
