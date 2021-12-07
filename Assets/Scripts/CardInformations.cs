using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Data/CardInformations", order = 1)]
public class CardInformations : ScriptableObject
{
    public string[] cardTitles, cardDescriptions;
    public Sprite[] cardImages;
}

[CreateAssetMenu(fileName = "CardEffects", menuName = "Data/CardEffects", order = 2)]
public class EffectOfCard : ScriptableObject
{
    public enum EffectType { HP, Mana, AttackSpeed};
    public EffectType effect;

    public float value = 1;
        
    public int RandomEffect()
    {
        return Random.Range(0, 3);
    }
}
