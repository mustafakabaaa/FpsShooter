using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject liveEnemy;
    public GameObject enemyPrefab;  // D��man�n prefab'�
    public float respawnDelay = 60f; // 60 saniye (1 dakika)
    private bool canSpawn = true; // Spawn i�leminin yap�l�p yap�lamayaca��n� kontrol etmek i�in kullan�lan boolean de�eri

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (canSpawn)
        {
            if (liveEnemy == null)
            {
                // liveEnemy null oldu�unda buraya ge�er ve spawn i�lemi yap�l�r
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                liveEnemy = newEnemy;

                // Spawn i�lemi yap�ld�ktan sonra belirli bir s�re bekleyerek tekrar kontrol etmek i�in
                yield return new WaitForSeconds(respawnDelay);
            }
            else
            {
                // liveEnemy null de�ilse bir sonraki kontrol i�in bir s�re bekleyin
                yield return null;
            }
        }
    }

    // Bir durumda spawn i�lemini durdurmak i�in bu fonksiyonu kullanabilirsiniz
    public void StopSpawn()
    {
        canSpawn = false;
    }
}
