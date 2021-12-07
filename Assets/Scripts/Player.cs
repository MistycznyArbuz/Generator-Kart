using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats
{
    public int HP, Mana, AttackSpeed;
}

public class Player : MonoBehaviour
{
    public PlayerStats playerStats = new PlayerStats();
    public TMP_Text hpText, manaText, attackSpeedText;

    private void Update()
    {
        hpText.text = "HP : " + playerStats.HP;
        manaText.text = "Mana : " + playerStats.Mana;
        attackSpeedText.text = "Attack Speed : " + playerStats.AttackSpeed;
    }
}
