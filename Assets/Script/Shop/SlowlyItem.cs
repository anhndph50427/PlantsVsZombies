using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowlyItem : MonoBehaviour
{
    [SerializeField] private SlowlySO Slowly;
    [SerializeField] private int IndexSlowly;
    [SerializeField] private int slowlyLevel;

    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI coolDownTxt;
    [SerializeField] private TextMeshProUGUI pointTxt;
    [SerializeField] private TextMeshProUGUI unlockCostTxt;
    [SerializeField] private Button UpgrateBtn;

    private void Start()
    {
        IndexSlowly = Slowly.indexLevel;
        loadAtribute();

        UpgrateBtn.onClick.AddListener(() => Upgrate());
        slowlyLevel = PlayerPrefs.GetInt("IndexSlowly");
    }

    private void Update()
    {
        PlayerPrefs.SetInt("IndexSlowly", IndexSlowly);
    }

    void loadAtribute()
    {
        nameTxt.text = Slowly.nameSkill;
        levelTxt.text = $"{slowlyLevel + 1}";
        coolDownTxt.text = Slowly.infor[slowlyLevel].coolDown.ToString();
        pointTxt.text = Slowly.infor[slowlyLevel].TimeStopMove.ToString();
        unlockCostTxt.text = Slowly.infor[slowlyLevel].UnlockCost.ToString();
    }

    void Upgrate()
    {

        slowlyLevel++;
        loadAtribute();
        if (slowlyLevel == Slowly.infor.Length - 1) UpgrateBtn.interactable = false;
    }
}
