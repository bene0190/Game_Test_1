using System.Collections.Generic;

[System.Serializable]
public class CharacterSaveData
{
    public string characterName;
    public int currentHP;
    public int currentSP;
    public int MaxHP;
    public int MaxSP;

    public List<SkillData> currentSkills = new List<SkillData>();

    public int hairID;
    public int bodyID;
    public int faceID;
    public string equippedWeapon;
}

