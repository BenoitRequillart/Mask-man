using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public event Action OnDeath;
    [SerializeField] private float invulTime = 0f;
    [SerializeField] private int numberOfFlashes = 0;
    private bool invulnerability = false;
    private SpriteRenderer spriteRend;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerability) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");

            if(gameObject.layer == 6)StartCoroutine(Invul());
        }
        else
        {
            if (!dead)
            {
                
                dead = true;
                OnDeath.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
    IEnumerator Invul()
    {
        if (gameObject.layer == 6) invulnerability = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invulTime / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulTime / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
        invulnerability = false;
    }
}