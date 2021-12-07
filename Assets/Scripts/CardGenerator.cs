using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    public CardInformations cardInformations;
    public GameObject cardPrefab;
    public Transform spawnPoint;

    public void Start()
    {
        RandomCard();
    }

    public void RandomCard()
    {
        GameObject card = Instantiate(cardPrefab, spawnPoint);
        card.GetComponent<Card>().title.text = cardInformations.cardTitles[Random.Range(0, cardInformations.cardTitles.Length)];
        card.GetComponent<Card>().descripton.text = cardInformations.cardDescriptions[Random.Range(0, cardInformations.cardDescriptions.Length)];
        card.GetComponent<Card>().image.sprite = cardInformations.cardImages[Random.Range(0, cardInformations.cardImages.Length)];
    }
}
