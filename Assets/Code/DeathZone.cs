using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Transform spawnPlayer;
    private Animator fadeSystem;

    private void Awake()
    {
        spawnPlayer = GameObject.FindGameObjectWithTag("SpawnPlayer").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Si je rentre en collison avec DeathZone je suis tp au spawn de base du niveau
        {
            StartCoroutine(ReplacePlayer(collision)); 
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = spawnPlayer.position;
    }
}
