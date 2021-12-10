using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public TMP_Text titleText, descriptionText;

    public string title, descripton;
    public Image image;

    public CardEffect cardEffect;

    void Update()
    {
        titleText.text = title;
        descriptionText.text = descripton;
    }
}
