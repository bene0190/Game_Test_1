using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player Economy")]
    public int currentMoney = 0;
    public int availableTime = 7; // e.g., 7 days in a week to do missions

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI timeText;

    [Header("System References")]
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        UpdateEconomyUI();
    }

    public void AttemptMission(MissionData targetMission)
    {
        if (availableTime >= targetMission.timeCost)
        {
            // Spend the time
            availableTime -= targetMission.timeCost;
            UpdateEconomyUI();

            // Note: In a full game, you'd pass the targetMission data to the CombatManager here
            // to spawn the correct enemies. For now, we just transition scenes.

            uiManager.StartCombat();
            Debug.Log($"Deployed on {targetMission.missionName}!");
        }
        else
        {
            Debug.Log("Not enough time remaining to deploy!");
        }
    }

    // Called when the Combat scene ends (Win condition)
    public void MissionVictory(MissionData completedMission)
    {
        currentMoney += completedMission.rewardMoney;
        UpdateEconomyUI();

        uiManager.OpenHub();
    }

    private void UpdateEconomyUI()
    {
        if (moneyText != null) moneyText.text = $"Money: ${currentMoney}";
        if (timeText != null) timeText.text = $"Time Left: {availableTime}";
    }
}

