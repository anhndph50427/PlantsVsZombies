using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBasic : ZombieBase
{
    [Header("Bến thể")]
    public GameObject Shield;
    private float healthMin;

    public bool ZombieV1 = false;
    public float heath_ZombieV1;

    public bool ZombieV2 = false;
    public float heath_ZombieV2;
    




    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();
        AudioSource = GetComponent<AudioSource>();

        healthMin = health;
        if (ZombieV1)
        {
            health = heath_ZombieV1;
        }
        else if (ZombieV2)
        {
            health = heath_ZombieV2;
        }

        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        

        if (checkCollision == true)
        {
            
            animator.SetBool("CheckAtk", true);
        }
        else
        {
            animator.SetBool("CheckAtk", false);
        }

        if (health <= healthMin && Shield != null)
        {
            Destroy(Shield);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            
            AudioSource.PlayOneShot(hitByBullet);
        }
    }

}
