using UnityEngine;
[CreateAssetMenu(fileName = "MowerData", menuName = "Shop/Mower", order = 0)]
public class MowerSO : SkillBaseSO
{
    public int indexLevel;
    public MowerContribute[] infor;
}

[System.Serializable]
public class MowerContribute
{
    public float coolDown;
    public float reduceSpeed;
    public float UnlockCost;
}