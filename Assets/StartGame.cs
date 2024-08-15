using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public AudioSource audioSource;
    public Image fadePanel;
    public float fadeOutDuration = 2.0f; 

    public void LoadGameScene()
    {
        StartCoroutine(FadeOutAndLoadScene("Game", fadeOutDuration));
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName, float duration)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;
        Color panelColor = fadePanel.color;
        float startAlpha = panelColor.a;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
            panelColor.a = Mathf.Lerp(startAlpha, 1, currentTime / duration);
            fadePanel.color = panelColor;
            yield return null;
        }

        audioSource.Stop();
        SceneManager.LoadScene(sceneName);
    }
}


