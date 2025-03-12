using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : PlantBase
{
    // Thời gian cần để PotatoMine mọc lên
    public float sproutTime = 10f;

    // Cờ để kiểm tra xem PotatoMine đã mọc lên hay chưa
    private bool isSprouted = false;

    public BoxCollider2D boxColliderOnEnable;

    public AudioClip sound;
    private AudioSource audioSource;

    protected override void Start()
    {
        audioSource = GetComponent<AudioSource>();
        base.Start();

        // Gọi hàm Sprout sau khi hết thời gian sproutTime
        Invoke("Sprout", sproutTime);
    }

    protected override void Update()
    {
        base.Update();
    }

    // Hàm để xử lý khi PotatoMine mọc lên
    public void Sprout()
    {
        isSprouted = true;
        animator.SetBool("TroiLen", true);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        // Kiểm tra nếu đối tượng va chạm có tag "Zombies" và PotatoMine đã mọc lên
        if (collider.CompareTag("Zombies") && isSprouted)
        {
            animator.SetTrigger("ATK");
            audioSource.PlayOneShot(sound);
            ZombieBase zom = collider.GetComponent<ZombieBase>();
            if (zom != null)
            {
                zom.takeDame(1800);
            }
        }
    }
    public void enableColliderOn()
    {
        boxColliderOnEnable.enabled = true;
    }
    public void enableColliderOff()
    {
        boxColliderOnEnable.enabled = false;
    }
    public void Death()
    {
        health = 0;
    }
}
