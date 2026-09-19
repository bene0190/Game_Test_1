using UnityEngine;

public enum SkillAnimationType { Sweep, Thrust, Punch }

[CreateAssetMenu(fileName = "NewSkill", menuName = "GameData/SkillData")]
public class SkillData : ScriptableObject
{
    public WeaponData wD;
    public string skillName;

    [Header("Combat Execution")]
    public SkillAnimationType animationType;

    public string weightReq;
    public bool PhysicsBox;
    public bool Canshoot;

    
}
