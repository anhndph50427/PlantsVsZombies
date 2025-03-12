using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float maxHealth = 1000f;
    private float currentHealth;
    private Animator animator;
    private CircleCollider2D attackCollider;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackCollider = GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (currentHealth <= 0)
        {
            animator.SetTrigger("dealth");
        }
        else if (currentHealth <= 500)
        {
            animator.SetBool("isLowHealth", true);
        }
        else
        {
            animator.SetBool("isLowHealth", false);
        }

        animator.SetBool("isAttacking", isAttacking);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plants"))
        {
            attackCollider.enabled = true;
            isAttacking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plants"))
        {
            isAttacking = false;
            attackCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Plants") && attackCollider.enabled)
        {
            PlantBase plant = collider.GetComponent<PlantBase>();
            if (plant != null)
            {
                //plant.TakeDamage(100);
            }
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
    }
}