using UnityEngine;

public class KinematicSwitch : MonoBehaviour
{
    private Rigidbody myRigidbody;

    void Start()
    {
        // Rigidbody bile�enini al
        myRigidbody = GetComponent<Rigidbody>();
        if (myRigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on the object.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // E�er ba�ka bir collider i�ine girdiyse
        if (other.CompareTag("Player")) // Burada "Player" yerine kullanmak istedi�iniz tag'i belirtin
        {
            // Rigidbody'nin isKinematic �zelli�ini false yap
            if (myRigidbody != null)
            {
                myRigidbody.isKinematic = false;
            }
        }
    }
}
