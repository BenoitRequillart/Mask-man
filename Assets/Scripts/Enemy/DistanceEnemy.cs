using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemy : MonoBehaviour
{
    [SerializeField]
    private float attackInterval;
    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask playerLayer;
    private float lastAttackCounter = Mathf.Infinity;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Health playerHealth;
    [SerializeField]
    private GameObject animals;
    [SerializeField]
    private GameObject projectile;
    public Transform gun;
    [SerializeField]
    private float colliderDistance;
    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        Health health = GetComponent<Health>();
        health.OnDeath += Drop;
        
    }

    // Update is called once per frame
    void Update()
    {
        lastAttackCounter += Time.deltaTime;


        Vector2 direction;
        if (lastAttackCounter >= attackInterval)
        {

            lastAttackCounter = 0;
            GameObject proj = Instantiate(projectile, gun.position, Quaternion.identity);
            if (sprite.flipX)
            {
                direction = new Vector2(-1, 0);
            }
            else
            {
                direction = new Vector2(1, 0);
            }
            ProjectileEnemy pro = proj.GetComponent<ProjectileEnemy>();
            pro.direction = direction;
            pro.lifeTime = range;
            pro.Launch();
        }

    }


    public bool PlayerInRange()
    {

        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.right, 0, playerLayer);

        return hit.collider != null;
    }

    private void Drop()
    {
        Vector3 spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.45f, gameObject.transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(animals, spawnPosition, spawnRotation);
    }
}
