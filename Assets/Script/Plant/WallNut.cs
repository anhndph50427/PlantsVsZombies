using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNut : PlantBase
{
    public float HP2;
    public float HP3;
    protected override void Start()
    {
        base.Start();
    }   

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (health <= HP2 && health > HP3)
        {
            animator.SetBool("HP2", true);
        }
        else if (health <= HP3)
        {
            animator.SetBool("HP3", true);
        }
    }
}
