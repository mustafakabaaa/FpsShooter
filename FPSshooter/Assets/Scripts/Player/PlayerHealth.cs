using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public AudioSource medicSound;
    public Image healthBar;
    private bool canHeal=true;

    public DamageIndicator damageIndicator;
    void Start()
    {
        health = maxHealth;
        UpdateHealthUI(); // Ba�lang��ta health bar�n� g�ncelle
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        //Debug.Log(health);
       
    }
    public void UpdateHealthUI()
    {
        float hFraction = health / maxHealth;
        float doluH = healthBar.fillAmount;

        if (doluH > hFraction)
        {
            lerpTimer += Time.deltaTime;
            float y�zdeTamam = Mathf.Pow(lerpTimer / chipSpeed, 2);
            y�zdeTamam = y�zdeTamam * y�zdeTamam;
            healthBar.fillAmount = Mathf.Lerp(doluH, hFraction, y�zdeTamam);
        }
        else
        {
            lerpTimer = 0f; // E�er health art�yorsa, lerpTimer'� s�f�rla
            healthBar.fillAmount = hFraction; // Health art�yorsa, direkt olarak hFraction'a ayarla
        }
    }
    public void Medic(float medica)
    {
        if (canHeal)
        {
            float maxHealtPlus = 45;
            if (medica > maxHealtPlus)
            {
                medica = maxHealtPlus;
            }
            float healTime = 10f;
            StartCoroutine(MedicCoroutine(medica, healTime));
            medicSound.Play();
            canHeal = false;
        }
        else
        {

        }
       
    }


    public void HasarAl(float hasar)
    {
        health -= hasar;
        health = Mathf.Clamp(health, 0, maxHealth); // Sa�l��� 0 ile maxHealth aras�nda tut
        UpdateHealthUI(); // Health g�ncellendikten sonra health bar�n� g�ncelle
        lerpTimer = 0f;

        // Hasar al�nf���nda DamageInd�cator calistir.
        if(damageIndicator!=null)
        {
            damageIndicator.ShowDamageIndicator();
        }
    }



    private IEnumerator MedicCoroutine(float medica, float totalHealTime)
    {
        float startingHealth = health;
        float targetHealth = Mathf.Clamp(health + medica, 0, maxHealth);

        float elapsedTime = 0f;

        while (elapsedTime < totalHealTime)
        {
            health = Mathf.Lerp(startingHealth, targetHealth, elapsedTime / totalHealTime);
            UpdateHealthUI();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        health = targetHealth;
        UpdateHealthUI();
        canHeal = true;
    }


}
