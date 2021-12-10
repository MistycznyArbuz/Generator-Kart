using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameManager gameManager;
    public static CardGenerator cardGenerator;
    public static CardInformations cardInformations;

    public delegate void GUIEvent();
    public static event GUIEvent OnGenerateClicked;
    public static event GUIEvent OnSaveClicked;
    public static event GUIEvent OnUseClicked;

    public static void GenerateButtonAction()
    {
        OnGenerateClicked();
    }

    public static void SaveToFileAction()
    {
        OnSaveClicked();
    }

    public static void UseCardAction()
    {
        OnUseClicked();
    }

    public static CardGenerator GiveCardGenerator()
    {
        return cardGenerator;
    }

    public static GameManager GiveGameManager()
    {
        return gameManager;
    }

    public static CardInformations GiveCardInformations()
    {
        return cardInformations;
    }
}
