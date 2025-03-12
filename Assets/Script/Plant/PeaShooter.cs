using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;

// Khai báo lớp PeaShooter thừa kế từ PlantBase
public class PeaShooter : PlantBase
{
    // Nhóm biến để lưu thông tin về Raycast
    [Header("Raycast info")]
    [SerializeField] private LayerMask whatIsMask; // Lớp mask để xác định đối tượng cần kiểm tra va chạm
    [SerializeField] private float distanceLimit; // Giới hạn khoảng cách của Raycast

    // Nhóm biến để lưu thông tin về bắn
    [Header("Shoot info")]
    [SerializeField] private GameObject bullet_prefabs; // Prefab của đạn
    [SerializeField] private Transform pos_Shoot; // Vị trí bắn đạn
    [SerializeField] private float fireRate; // Tốc độ bắn
    private float canFire; // Thời gian có thể bắn tiếp

    // Nhóm biến để lưu âm thanh bắn
    [Header("Audio info")]
    public AudioClip shootSound; // Âm thanh khi bắn đạn
    private AudioSource audioSource; // Nguồn âm thanh

    // Hàm khởi tạo ban đầu
     protected override void Start()
    {
        base.Start(); // Gọi hàm Start của lớp cha
        canFire = 0; // Khởi tạo thời gian bắn bằng 0
        distanceLimit = Mathf.Abs(distanceLimit); // Đảm bảo giới hạn khoảng cách luôn dương
        audioSource = GetComponent<AudioSource>();
    }

    // Hàm cập nhật hàng khung hình
    protected override void Update()
    {
        base.Update(); // Gọi hàm Update của lớp cha
        Attack(); // Gọi hàm Attack để kiểm tra và tấn công zombie
    }

    // Hàm để xử lý việc tấn công
    private void Attack()
    {
        // Kiểm tra xem có zombie trong vùng tấn công không
        if (ZombiesDetected().collider != null)
        {
            Debug.Log(ZombiesDetected().collider.name);
            animator.SetBool("check", true); // Đặt biến check của animator thành true nếu phát hiện zombie
        }
        else
        {
            animator.SetBool("check", false);
            
        }
    }

    // Hàm để bắn đạn
    private void Shooting()
    {
        // Kiểm tra nếu chưa đủ thời gian để bắn tiếp thì thoát khỏi hàm
        // if (!(canFire < Time.time)) return;

        // Tạo mới một viên đạn tại vị trí bắn
        GameObject newBullet = Instantiate(bullet_prefabs, pos_Shoot.position, Quaternion.identity);
        // Hủy viên đạn sau 4 giây
        Destroy(newBullet, 4f);
        
        // Cập nhật thời gian có thể bắn tiếp
        // canFire = Time.time + fireRate;

        if(shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
            Debug.Log("âm thanh bắn");
        }
        
        else Debug.Log("không nhận âm thanh");

        if (audioSource == null)
        {
           
            Debug.Log("audioSound Null");
        }
       
    }

    // Hàm để phát hiện zombie bằng Raycast
    RaycastHit2D ZombiesDetected() => Physics2D.Raycast(transform.position, Vector2.right, distanceLimit, whatIsMask);

    // Hàm để vẽ đường Raycast trong chế độ Gizmos 
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + distanceLimit, transform.position.y, 0));
    }
}
