using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField]
    private float attackInterval;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int range;
    [SerializeField]
    private LayerMask playerLayer;
    private float lastAttackCounter = Mathf.Infinity;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    private Animator anim;
    private Health playerHealth;
    private EnemyMovement movement;
    [SerializeField]
    private GameObject animals;
    // Start is called before the first frame update
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        movement = GetComponent<EnemyMovement>();
        movement.OnFlipX += FlipEnemy;
        Health health = GetComponent<Health>();
        health.OnDeath += Drop;
    }

    // Update is called once per frame
    void Update()
    {
        lastAttackCounter += Time.deltaTime;
        
        if (PlayerInRange())
        {
            if (lastAttackCounter >= attackInterval)
            {
                lastAttackCounter = 0;
                anim.SetTrigger("melee");
            }
        }
    }


    public bool PlayerInRange()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range, boxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);
        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range, boxCollider.bounds.size);
    //}

    private void DamagePlayer()
    {
        if (PlayerInRange())
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void FlipEnemy()
    {
        sprite.flipX = !sprite.flipX;
        FlipRange();
    }
    private void FlipRange()
    {
        range = range * -1;
    }

    private void Drop()
    {
        Vector3 spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.45f, gameObject.transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(animals, spawnPosition, spawnRotation);
    }
}
