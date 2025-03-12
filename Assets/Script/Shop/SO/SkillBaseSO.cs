using UnityEngine;

public class SkillBaseSO : ScriptableObject
{
    public string nameSkill;
    public TypeSkill typeSkill;
}

public enum TypeSkill
{
    Push_Water,
    SLOWLY,
    MOWER
}
