using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;
    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //Normalise pour que le vecteur ait tjrs la même taille

        if(Vector3.Distance(transform.position, target.position) < 0.3f) //distance entre deux entité, si l'ennemi est arrivé à sa dest alors
        {
            destPoint = (destPoint + 1) % waypoints.Length; //Si il a fait tout les point, on reprend du début (grâce au %)
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
}
