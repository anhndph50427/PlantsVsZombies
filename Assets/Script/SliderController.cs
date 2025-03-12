using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI GameTime;
    public float maxTime = 10f;     // Thời gian tối đa (giây)
    private float currentTime;      // Thời gian hiện tại
   

    void Start()
    {
        
        if (slider == null)
        {
            Debug.LogError("Slider chưa được gán");
            return;
        }

        // Đặt giá trị max của slider thành maxTime
        slider.maxValue = maxTime;
        slider.value = maxTime; // Bắt đầu từ đầy (phải) và giảm dần

        currentTime = maxTime;
    }
    void Update()
    {
        currentTime = GamePlay.GameTime;

        if (GameTime != null)
        {
            GameTime.text = Mathf.RoundToInt(currentTime).ToString() + "s";
        }
        if (currentTime > 0)
        {
            // Giảm thời gian hiện tại dựa trên thời gian thực của game
            currentTime = maxTime - currentTime;
            slider.value = currentTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                // Thực hiện hành động khi thời gian kết thúc
                Debug.Log("Thời gian đã kết thúc!");
            }
        }
    }
}
