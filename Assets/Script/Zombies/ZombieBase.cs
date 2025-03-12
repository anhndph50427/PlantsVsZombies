using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected float Atk;
    protected Animator animator;
    protected SpriteRenderer sr;

    [SerializeField] protected AudioClip hitByBullet;
    [SerializeField] protected AudioClip audioAtk;
    protected AudioSource AudioSource;

    public bool canMove = false;
    protected bool checkCollision = false;

    private PlantBase plantBase;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();
        plantBase = FindObjectOfType<PlantBase>(); // Tìm PlantBase trong toàn cảnh
        if (plantBase == null)
        {
            //Debug.Log("plantBase null");
        }
    }
    protected virtual void Update()
    {
        if (canMove == true)
        {
            moving(speed);
        }

        if (health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        GamePlay.instance.deadZombies++;
        //animator.SetBool("CheckDeath", true);
        Destroy(gameObject/*, 1.5f*/);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Plant"))
        {
            checkCollision = true;
            stopMove();
            Debug.Log("Đã dừng di chuyển");

            // Cập nhật plantBase
            plantBase = collision.gameObject.GetComponent<PlantBase>();
            if (plantBase != null)
            {
                Debug.Log("PlantBase đã được gán thành công.");
            }
            else
            {
                Debug.LogError("Không thể gán PlantBase từ va chạm.");
            }
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Plant"))
        {

            // tạm dừng di chuyển khi gặp palnt
            checkCollision = false;
            startMove();
            Debug.Log("tiếp tục di chuyển");
        }
    }

    protected void Attack()
    {
        if (plantBase != null)
        {
            Debug.Log("Đang tấn công plantBase.");
            plantBase.takeDame(Atk);
            AudioSource.PlayOneShot(audioAtk);
        }
        else
        {
            Debug.LogError("PlantBase is null");
        }
    }

    protected void startMove()
    {
        canMove = true;
    }
    protected void stopMove()
    {
        canMove = false;
    }
    //
    public void moving(float x)
    {
        transform.Translate(Vector2.left * x * Time.deltaTime);
    }

    

    public void takeDame(float dame)
    {
        health -= dame;
        StartCoroutine(flashFx());
    }

    IEnumerator flashFx()
    {
        Color original = sr.color;
        sr.color = new Color(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        //sr.color = new Color(1f, 1, 1);
        sr.color = original;
    }
}
