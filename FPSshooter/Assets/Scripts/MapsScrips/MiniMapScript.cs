using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform takipEdilecekNesne;  // Oyuncuyu i�eren nesnenin Transform bile�eni

    void LateUpdate()
    {
        if (takipEdilecekNesne != null)
        {
            // Minimap kameras�n� oyuncuyu takip edecek �ekilde konumland�r
            transform.position = new Vector3(takipEdilecekNesne.position.x, transform.position.y, takipEdilecekNesne.position.z);
        }
    }
}


