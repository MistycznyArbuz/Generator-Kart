using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public CardInformations cardInformations;
    public CardEffect[] cardEffects;
    public GameObject cardPrefab;
    public Card actualCard;
    public Transform spawnPoint;

    void OnEnable()
    {
        GameEvents.OnGenerateClicked += RandomCard;
    }

    void OnDisable()
    {
        GameEvents.OnGenerateClicked -= RandomCard;
    }

    public void RandomCard()
    {
        if (actualCard != null)
            Destroy(actualCard.gameObject);
        GameObject card = Instantiate(cardPrefab, spawnPoint);
        actualCard = card.GetComponent<Card>();
        actualCard.GetComponent<Card>().cardEffect = cardEffects[Random.Range(0, cardEffects.Length)];

        if (actualCard.GetComponent<Card>().cardEffect.type == CardEffect.CardType.Weapon)
        {
            actualCard.GetComponent<Card>().title.text = cardInformations.weaponTitles[Random.Range(0, cardInformations.weaponTitles.Length)];
            actualCard.GetComponent<Card>().descripton.text = cardInformations.weaponDescriptions[Random.Range(0, cardInformations.weaponDescriptions.Length)];
            actualCard.GetComponent<Card>().image.sprite = cardInformations.weaponImages[Random.Range(0, cardInformations.weaponImages.Length)];
            actualCard.GetComponent<Card>().cardEffect.attackSpeed = Random.Range(2, 8);
        }
        else if (actualCard.GetComponent<Card>().cardEffect.type == CardEffect.CardType.Armor)
        {
            actualCard.GetComponent<Card>().title.text = cardInformations.armorTitles[Random.Range(0, cardInformations.armorTitles.Length)];
            actualCard.GetComponent<Card>().descripton.text = cardInformations.armorDescriptions[Random.Range(0, cardInformations.armorDescriptions.Length)];
            actualCard.GetComponent<Card>().image.sprite = cardInformations.armorImages[Random.Range(0, cardInformations.armorImages.Length)];
            actualCard.GetComponent<Card>().cardEffect.hp = Random.Range(10, 50);
        }
        else if (actualCard.GetComponent<Card>().cardEffect.type == CardEffect.CardType.Magic)
        {
            actualCard.GetComponent<Card>().title.text = cardInformations.magicTitles[Random.Range(0, cardInformations.magicTitles.Length)];
            actualCard.GetComponent<Card>().descripton.text = cardInformations.magicDescriptions[Random.Range(0, cardInformations.magicDescriptions.Length)];
            actualCard.GetComponent<Card>().image.sprite = cardInformations.magicImages[Random.Range(0, cardInformations.magicImages.Length)];
            actualCard.GetComponent<Card>().cardEffect.mana = Random.Range(5, 20);
        }

        gameManager.SaveToFile();
    }
}
