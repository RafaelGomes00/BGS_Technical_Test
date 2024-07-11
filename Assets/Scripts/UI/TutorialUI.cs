using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerInteractionText;
    [SerializeField] TextMeshProUGUI playerMovementText;
    [SerializeField] TextMeshProUGUI playerInventoryText;

    [SerializeField] Animator tutorialAnimator;

    bool interactedWithInventory;
    bool interactedWithEnviroment;
    bool moved;

    public void OnPlayerInteract()
    {
        playerInteractionText.fontStyle = FontStyles.Strikethrough;
        interactedWithEnviroment = true;
        CheckSteps();
    }

    public void OnPlayerMove()
    {
        playerMovementText.fontStyle = FontStyles.Strikethrough;
        moved = true;
        CheckSteps();
    }

    public void OnPlayerOpenInventory()
    {
        playerInventoryText.fontStyle = FontStyles.Strikethrough;
        interactedWithInventory = true;
        CheckSteps();
    }

    public void OpenTutorial()
    {
        if (tutorialAnimator.IsInTransition(0)) return;

        playerInteractionText.fontStyle = FontStyles.Normal;
        playerInventoryText.fontStyle = FontStyles.Normal;
        playerMovementText.fontStyle = FontStyles.Normal;

        interactedWithEnviroment = false;
        interactedWithInventory = false;
        moved = false;
        tutorialAnimator.SetTrigger("OpenTutorial");
    }

    private void CheckSteps()
    {
        if (interactedWithEnviroment && interactedWithInventory && moved)
        {
            CloseTutorial();
        }
    }

    private void CloseTutorial()
    {
        tutorialAnimator.SetTrigger("CloseTutorial");
    }
}
