using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position; //On récupère le joueur et on le met au position de spawn du prochain niveau
    }
}
