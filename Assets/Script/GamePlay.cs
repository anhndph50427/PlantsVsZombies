using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class GamePlay : MonoBehaviour
{
    // Thuộc tính singleton để truy cập GamePlay từ bất kỳ đâu
    public static GamePlay instance { get; private set; }

    // LayerMask để xác định lớp các đối tượng mà Raycast sẽ kiểm tra va chạm
    public LayerMask whatIsMask;

    // Biến để lưu trữ số điểm sunScore
    public int sunScore;

    public SpawnZombie SpawnZombiee;
    public int numberOfZombies;
    public int deadZombies;

    public TextMeshProUGUI WinGame_time;

    private bool stopGame = false;

    
    private AudioSource audioSource;

    [SerializeField] EndGame endGame;
    public static float GameTime { get; set; }

    // Phương thức Awake được gọi khi script này được khởi tạo
    private void Awake()
    {
        // Thiết lập singleton instance
        instance = this;

    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
        
        numberOfZombies = SpawnZombiee.notifications.Count;
        WinGame_time.text = GameTime.ToString("F1");

    }
    // Phương thức Update được gọi một lần mỗi khung hình
    private void Update()
    {
        GameTime += Time.deltaTime;
        // Tạo một Raycast từ vị trí của chuột trong thế giới tới điểm không giới hạn (Mathf.Infinity)
        RaycastHit2D touch = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, whatIsMask);

        // Kiểm tra nếu raycast trúng một collider
        if (touch.collider != null)
        {
            // Nếu nhấp chuột trái (chuột số 0) được thực hiện
            if (Input.GetMouseButtonDown(0))
            {
                // Thiết lập biến isTouch của đối tượng bị va chạm thành true
                touch.collider.gameObject.GetComponent<Sun>().isTouch = true;
            }
        }

        if(numberOfZombies == deadZombies)
        {
            Debug.Log("Win Game !!!");
            
            endGame.winGame();
            WinGame_time.text = GameTime.ToString();

            WinGame_time.text = GameTime.ToString("F1") + " Giây";

        }
    }
    public void gamePaused()
    {
        stopGame = !stopGame;
        if (stopGame)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    
}
