using TMPro;
//using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class PushWaterItem : MonoBehaviour
{
    [SerializeField] private PushWaterSO PushWater;
    [SerializeField] private int indexLevel;
    [SerializeField] private int indexSave;

    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI coolDownTxt;
    [SerializeField] private TextMeshProUGUI pointTxt;
    [SerializeField] private TextMeshProUGUI unlockCostTxt;
    [SerializeField] private Button UpgrateBtn;

    private void Start()
    {
        loadAtribute();
        UpgrateBtn.onClick.AddListener(() => Upgrate());
    }


    void loadAtribute()
    {
        nameTxt.text = PushWater.nameSkill;
        levelTxt.text = $"{indexLevel + 1}";
        coolDownTxt.text = PushWater.infor[indexLevel].coolDonw.ToString();
        pointTxt.text = PushWater.infor[indexLevel].force.ToString();
        unlockCostTxt.text = PushWater.infor[indexLevel].UnlockCost.ToString();
    }

    void Upgrate()
    {

        if (ShopUI.instance.Coins >= PushWater.infor[indexLevel].UnlockCost)
        {
            indexLevel++;
            ShopUI.instance.Coins -= PushWater.infor[indexLevel].UnlockCost;
            loadAtribute();
            

        }
        
        if (indexLevel == PushWater.infor.Length - 1) UpgrateBtn.interactable = false;


    }
}
