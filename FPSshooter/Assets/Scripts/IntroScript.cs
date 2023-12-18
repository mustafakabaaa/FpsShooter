using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 5f;

    void Start()
    {
        // Alpha de�erini 0.0f (tamamen �effaf) olarak ayarla
        canvasGroup.alpha = 0.0f;

        // Alpha de�erini zamanla de�i�tirmek i�in coroutine ba�lat
        StartCoroutine(FadeInImage());
    }

    IEnumerator FadeInImage()
    {
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            // Alpha de�erini artt�r
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);

            // Zaman� g�ncelle
            currentTime += Time.deltaTime;

            yield return null; // Bir frame beklet
        }

        // 5 saniye sonra di�er sahneye ge�
        yield return new WaitForSeconds(3f);

        // �kinci sahneye ge�i� yap
        SwitchToNextScene();
    }

    void SwitchToNextScene()
    {
       
        SceneManager.LoadScene(1);
    }
}
