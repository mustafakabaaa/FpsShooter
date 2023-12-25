using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class ValueSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer AuMixer;
    [SerializeField] private Slider musicSlider;

    void Start()
    {
        // Daha �nce kaydedilmi� bir ses seviyesi varsa y�klenir
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSlider.value = savedVolume;
            SetMusicVolume(); // Ayar� uygula
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        AuMixer.SetFloat("music", Mathf.Log10((float)volume) * 20);

        // Ses seviyesini PlayerPrefs'e kaydet
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
}

