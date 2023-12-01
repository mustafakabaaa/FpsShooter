using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSFX : MonoBehaviour
{
    public AudioClip clickSound; // Sesi depolamak i�in bir de�i�ken
    private Button button; // Buton referans�

    void Start()
    {
        // Buton referans�n� al
        button = GetComponent<Button>();

        // Butonun t�klama olay�na fonksiyonu ba�la
        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound()
    {
        // Ses dosyas�n� �al
        if (clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        }
    }
}
