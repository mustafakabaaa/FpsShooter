using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionController : MonoBehaviour
{
    void Start()
    {
        // Oyuncuyu ta��may� sa�la
        DontDestroyOnLoad(gameObject);

        // Yeni sahne y�klendi�inde �a�r�lacak olan metodun dinleyicisini ekle
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne y�klendi�inde, oyuncunun konumunu ayarla
        if (scene.name == "SeconspMap")
        {
            // �stedi�iniz konumu ayarlay�n
            transform.position = new Vector3(0f, 2f, 0f);
        }
    }
}
