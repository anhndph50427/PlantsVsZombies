using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : MonoBehaviour
{
    [SerializeField] protected float health;
    protected Animator animator;
    protected SpriteRenderer sr;

    
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    { 
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDame(float dame)
    {
        Debug.Log($"PlantBase nhận {dame} sát thương.");
        health -= dame;
        StartCoroutine(flashFx());
    }

    
    IEnumerator flashFx()
    {
        if (sr == null)
        {
            Debug.LogError("SpriteRenderer is not assigned");
            yield break;
        }
        sr.color = new Color(0.8f, 0.8f, 0.8f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1, 1);
    }
}
