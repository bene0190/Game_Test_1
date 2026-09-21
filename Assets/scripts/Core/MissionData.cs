using UnityEngine;

[CreateAssetMenu(fileName = "NewMission", menuName = "GameData/MissionData")]
public class MissionData : ScriptableObject
{
    public string missionName;
    public string description;
    public Sprite missionImage;
    public int rank;
    public int rewardMoney;
    public int timeCost;
}