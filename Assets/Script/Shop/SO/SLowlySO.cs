using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slowly", menuName = "Shop/Slowly", order = 1)]
public class SlowlySO : SkillBaseSO
{
    public int indexLevel;
    public SlowlyAtribute[] infor;
}

[System.Serializable]
public class SlowlyAtribute
{
    public float coolDown;
    public float TimeStopMove;
    public int UnlockCost;
}
