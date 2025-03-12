using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : PlantBase
{
    [SerializeField] private float eatDuration = 10f;
    private bool isEating = false;

    public AudioClip sound;
    private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        base.Update();
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombies") && !isEating)
        {
            StartCoroutine(EatZombie(collision.gameObject));
        }
    }

    
    

    private IEnumerator EatZombie(GameObject zombie)
    {
        isEating = true;

        animator.SetTrigger("PreparingToEat");
        audioSource.PlayOneShot(sound);

        yield return new WaitForSeconds(0.5f);
        ZombieBase zombieBase = zombie.GetComponent<ZombieBase>();
        zombieBase.takeDame(1800f);

        animator.SetTrigger("Eat");

        yield return new WaitForSeconds(eatDuration);

        isEating = false;

        animator.SetTrigger("Idle");
    }

    /*private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Zombies") && collider.GetComponent<CircleCollider2D>().enabled)
        {
            //TakeDamage(100);
        }
    }*/
}