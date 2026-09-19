using UnityEngine;
using static UIManager;

public class UIManager : MonoBehaviour
{
    public enum UIPanelState
    {
        Hub, 
        MissionSelect, 
        Roster, 
        Combat
    }
    [Header("Core UI Panels")]
    [SerializeField] private GameObject panelHub;
    [SerializeField] private GameObject panelMissionSelect;
    [SerializeField] private GameObject panelRoster;
    [SerializeField] private GameObject panelCombat;

    private UIPanelState currentState;


private void Start() => ChangeState(UIPanelState.Hub);
    public void ChangeState(UIPanelState newState)
    {
        currentState = newState;

        panelHub.SetActive(currentState == UIPanelState.Hub);
        panelMissionSelect.SetActive(currentState == UIPanelState.MissionSelect);
        panelRoster.SetActive(currentState == UIPanelState.Roster);

        if (panelCombat != null)
            panelCombat.SetActive(currentState == UIPanelState.Combat);
    }

    public void OpenHub() => ChangeState(UIPanelState.Hub);
    public void OpenMissionSelect() => ChangeState(UIPanelState.MissionSelect);
    public void OpenRoster() => ChangeState(UIPanelState.Roster);
    public void StartCombat() => ChangeState(UIPanelState.Combat);
}
