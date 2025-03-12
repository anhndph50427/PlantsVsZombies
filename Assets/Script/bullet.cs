using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    public float AtkBullet;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ZombieBase>() != null)
        {
            collision.GetComponent<ZombieBase>().takeDame(AtkBullet);
        }


        if (collision.CompareTag("Zombies"))
        {
            Debug.Log("Va chạm: " + collision.name);
            Destroy(gameObject);
        }
    }
}
