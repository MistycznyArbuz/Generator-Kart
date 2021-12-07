using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEffects", menuName = "Data/CardEffects", order = 1)]
public class CardEffect : ScriptableObject
{
    public enum EffectType { Heal, Buff, Debuff};
    public EffectType type;
    public int hp;
    public int mana;
    public float attackSpeed;
}
