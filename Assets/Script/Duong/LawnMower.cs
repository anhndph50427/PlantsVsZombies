using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMower : MonoBehaviour
{
    public float speed;
    private bool isActivated = false;
    public AudioClip sound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isActivated)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombies"))
        {
            isActivated = true;
            audioSource.PlayOneShot(sound);
            ZombieBase zombie = collision.gameObject.GetComponent<ZombieBase>();
            zombie.takeDame(1800f);
            Destroy(gameObject, 4f);
        }
    }
}
