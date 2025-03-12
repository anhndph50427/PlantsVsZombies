using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MowerItem : MonoBehaviour
{
    [SerializeField] private MowerSO mower;
    [SerializeField] private int IndexMower;
    [SerializeField] private int CountIndex;

    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI coolDownTxt;
    [SerializeField] private TextMeshProUGUI pointTxt;
    [SerializeField] private TextMeshProUGUI unlockCostTxt;
    [SerializeField] private Button UpgrateBtn;

    private void Start()
    {
        IndexMower = mower.indexLevel;
        PlayerPrefs.SetInt("IndexMower", IndexMower);
        Debug.Log(PlayerPrefs.GetInt("IndexMower"));

        CountIndex = PlayerPrefs.GetInt("IndexMower");
        loadAtribute();

        UpgrateBtn.onClick.AddListener(() => Upgrate());

    }

    private void Update()
    {
        PlayerPrefs.SetInt("IndexMower", IndexMower);
    }

    void loadAtribute()
    {
        nameTxt.text = mower.nameSkill;
        levelTxt.text = $"{CountIndex + 1}";
        coolDownTxt.text = mower.infor[CountIndex].coolDown.ToString();
        pointTxt.text = mower.infor[CountIndex].reduceSpeed.ToString();
        unlockCostTxt.text = mower.infor[CountIndex].UnlockCost.ToString();
    }

    void Upgrate()
    {
        CountIndex++;

        loadAtribute();
        if (CountIndex == mower.infor.Length - 1) UpgrateBtn.interactable = false;
    }
}
