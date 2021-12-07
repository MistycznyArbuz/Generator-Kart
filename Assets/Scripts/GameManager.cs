using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardGenerator cardGenerator;
    public GameObject player;

    public void GenerateButton()
    {
        cardGenerator.RandomCard();
    }

    public void SaveCard()
    {

    }

    public void UseCard()
    {
        player.GetComponent<Player>().playerStats.HP += cardGenerator.actualCard.cardEffect.hp;
        player.GetComponent<Player>().playerStats.Mana += cardGenerator.actualCard.cardEffect.mana;
        player.GetComponent<Player>().playerStats.AttackSpeed += cardGenerator.actualCard.cardEffect.attackSpeed;

        cardGenerator.RandomCard();
    }
}
