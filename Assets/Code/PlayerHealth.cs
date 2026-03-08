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
    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plusieurs instance de PlayerHealth");
        }
        instance = this; 
    }
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

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage (int damage) //Test pour voir quand on prend des dégats
    {
        if(!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);   //Actualise les pv

            if(currentHealth <= 0) //Verifie si le joueur est toujours en vie
            {
                Die();
                return;
            }

            isInvicible = true;
            StartCoroutine(IncivibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());

        }
        
    }

    public void Die()
    {
        //Bloquer mouvement player
        PlayerMovement.instance.enabled = false;
        //Jouer animation de mort
        PlayerMovement.instance.animator.SetTrigger("Death");
        //Empecher interactions physiques avec autres élements
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.linearVelocity = Vector3.zero;  //Met la vitesse à zéro, on coupe le déplacement
        PlayerMovement.instance.playerCollider.enabled = false;
        //Active menu de GameOver
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovement.instance.enabled = true; //reactive deplacement player
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic; //Réactive interactions physiques avec autres élements
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator IncivibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color (1f, 1f, 1f, 0f); //On met alpha à 0 pour rendre Gaston transparent
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color (1f, 1f, 1f, 1f); //On met alpha à 1 pour rendre Gaston apparent
            yield return new WaitForSeconds(invicibilityFlashDelay);            
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
