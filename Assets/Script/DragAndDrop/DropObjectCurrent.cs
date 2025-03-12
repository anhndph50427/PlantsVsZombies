using TMPro;
using UnityEngine;

public class DropObjectCurrent : MonoBehaviour
{
    public static GameObject objectCurrent;

    public TextMeshProUGUI UIsunScore;

    private void Start()
    {
        UIsunScore.text = GamePlay.instance.sunScore.ToString();
    }

    private void Update()
    {
        UIsunScore.text = GamePlay.instance.sunScore.ToString();
    }
}
