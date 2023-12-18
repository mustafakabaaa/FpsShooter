using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeadControl : MonoBehaviour
{
    public Image RedScreen;
    public RectTransform ScreenA;

    void Start()
    {
        // K�rm�z� ekran� ba�lang��ta gizle
        RedScreen.color = new Color(1f, 0f, 0f, 0f);
    }

    void Update()
    {
        // Karakter �ld���nde
        if (GetComponent<PlayerHealth>().health <= 0)
        {
            StartCoroutine(DeadAnimation());
        }
    }

    IEnumerator DeadAnimation()
    {
        // K�rm�z� ekran efektini aktif hale getir
        StartCoroutine(FadeIn(RedScreen, 4f));

        // Bekleme s�resi (k�rm�z� ekran�n g�r�nmesi i�in)
        float beklemeSuresi = 3f; // �rne�in 3 saniye bekleyelim
        yield return new WaitForSeconds(beklemeSuresi);

        // Ekran�n A �zelli�ini y�kselterek ��kart
        while (ScreenA.anchoredPosition.y < 100f) // 100 de�eri �rnek bir hedef de�erdir, kendi oyununuzda uygun bir de�er se�in
        {
            ScreenA.anchoredPosition += new Vector2(0f, 1f) * Time.deltaTime * 50f; // 50 de�eri �rnek bir h�zd�r, kendi oyununuzda uygun bir de�er se�in
            yield return null;
        }

        // Sahne de�i�imi
        SceneManager.LoadScene(4); // "SonrakiSahne" k�sm�n� kendi sahnenizle de�i�tirin
    }

    IEnumerator FadeIn(Image image, float fadeTime)
    {
        float elapsedTime = 0f;
        Color startColor = image.color;

        while (elapsedTime < fadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(startColor.r, startColor.g, startColor.b, 1f); // Tamamen g�r�n�r yap
    }
}
