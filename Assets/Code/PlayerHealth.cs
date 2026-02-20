using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100; //Point de vie par défaut
    public int currentHealth; //Point de vie actuel
    public float invicibilityTimeAfterHit = 2f;
    public float invicibilityFlashDelay = 0.2f;

    public bool isInvicible = false;
    public SpriteRenderer graphics;
    public BarreDeVie healthBar; 
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage (int damage) //Test pour voir quand on prend des dégats
    {
        if(!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);   //Actualise les pv
            isInvicible = true;
            StartCoroutine(IncivibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());

        }
        
    }

    public IEnumerator IncivibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color (1f, 1f, 1f, 0f); //On met alpho à 0 pour rendre Gaston transparent
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color (1f, 1f, 1f, 1f); //On met alpho à 1 pour rendre Gaston apparent
            yield return new WaitForSeconds(invicibilityFlashDelay);            
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
