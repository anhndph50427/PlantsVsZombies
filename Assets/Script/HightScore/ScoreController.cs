using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankTxt;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI TimeTxt;

    public void SetDataText(HighScoreContent data)
    {
        rankTxt.text = data.rank.ToString();
        nameTxt.text = data.name;
        TimeTxt.text = chageTime(data.Time);
    }


    string chageTime(float timeSecond)
    {
        int minute = (int)timeSecond / 60;
        int second = (int)timeSecond % 60;
        return $"{minute}:{second}";
    }
}
