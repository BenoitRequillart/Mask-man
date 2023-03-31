using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction;

    public float lifeTime = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    public void Launch()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Projectile"))
        {

            Destroy(gameObject);
        }
    }
}
