using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private MeleeEnemy enemy;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    public event Action OnFlipX;
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            
            if (transform.position.x > leftEdge && !enemy.PlayerInRange())
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if(transform.position.x <= leftEdge)
            {
                OnFlipX?.Invoke();
                movingLeft = false;
            }
           
                
        }
        else if(!movingLeft)
        {
            if (transform.position.x < rightEdge && !enemy.PlayerInRange())
            {
                
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if(transform.position.x >= rightEdge)
            {
                movingLeft = true;
                OnFlipX?.Invoke();
            }
        }
    }
}
