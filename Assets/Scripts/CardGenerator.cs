using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    public CardInformations cardInformations;
    public CardEffect[] cardEffects;
    public GameObject cardPrefab;
    public Card actualCard;
    public Transform spawnPoint;

    public void Start()
    {
        RandomCard();
    }

    public void RandomCard()
    {
        if (actualCard != null)
            Destroy(actualCard.gameObject);
        GameObject card = Instantiate(cardPrefab, spawnPoint);
        actualCard = card.GetComponent<Card>();
        actualCard.GetComponent<Card>().title.text = cardInformations.cardTitles[Random.Range(0, cardInformations.cardTitles.Length)];
        actualCard.GetComponent<Card>().descripton.text = cardInformations.cardDescriptions[Random.Range(0, cardInformations.cardDescriptions.Length)];
        actualCard.GetComponent<Card>().image.sprite = cardInformations.cardImages[Random.Range(0, cardInformations.cardImages.Length)];
        actualCard.GetComponent<Card>().cardEffect = cardEffects[Random.Range(0, cardEffects.Length)];
    }
}
