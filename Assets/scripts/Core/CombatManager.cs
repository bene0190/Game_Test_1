using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CombatManager : MonoBehaviour
{
    [Header("Core References")]
    [SerializeField] private WeaponAnimator playerAnimator;

    [Header("UI Visualization")]
    [SerializeField] private Transform conveyorBeltUIContainer;
    [SerializeField] private GameObject cardPrefab;

    [Header("Conveyor Belt State")]
    public List<SkillData> conveyorBelt = new List<SkillData>();
    public int currentResource = 0;

    public void ExecuteNextAction()
    {
        if (conveyorBelt.Count > 0)
        {
            SkillData activeCard = conveyorBelt[0];
            playerAnimator.PlayAnimation(activeCard.animationType);
            conveyorBelt.RemoveAt(0);
        }
        else
        {
            playerAnimator.PlayAnimation(SkillAnimationType.Sweep);
            currentResource++;
        }

        RefreshBeltUI(); // Update the visuals after an action
    }

    public void Debug_AddCardToBelt(SkillData cardToAdd)
    {
        conveyorBelt.Add(cardToAdd);
        RefreshBeltUI(); // Update the visuals when drawing
    }

    private void RefreshBeltUI()
    {
        // 1. Destroy all current visual cards to prevent duplicates
        foreach (Transform child in conveyorBeltUIContainer)
        {
            Destroy(child.gameObject);
        }

        // 2. Spawn a new visual card for every item in the list
        foreach (SkillData skill in conveyorBelt)
        {
            GameObject newCard = Instantiate(cardPrefab, conveyorBeltUIContainer);

            // Find the Text component and set it to the skill's name
            newCard.transform.Find("Txt_SkillName").GetComponent<TextMeshProUGUI>().text = skill.skillName;
        }
    }
}

