using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBomb : PlantBase
{
    public AudioClip sound;
    private AudioSource audioSource;
    protected override void Start()
    {
        audioSource = GetComponent<AudioSource>();
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Atk()
    {
        if (animator != null)
        {
            audioSource.PlayOneShot(sound);
            animator.SetTrigger("ATK");
        }
    }

    public void Death()
    {
        health = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        {
            ZombieBase zomBase = collision.gameObject.GetComponent<ZombieBase>();
            if (zomBase != null)
            {
                zomBase.takeDame(1800f);
            }
            
        }
    }
}
