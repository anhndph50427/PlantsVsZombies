using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PushDWaterData" , menuName = "Shop/PusWater" , order = 0)]
public class PushWaterSO : SkillBaseSO
{
    public int indextLevel;
    public PushWaterAtribute[] infor;
}

[System.Serializable]
public class PushWaterAtribute
{
    public float coolDonw;
    public Vector2 force;
    public int UnlockCost;
}
