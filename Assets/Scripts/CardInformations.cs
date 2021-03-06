using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Data/CardInformations", order = 2)]
public class CardInformations : ScriptableObject
{
    public string[] weaponTitles, armorTitles, weaponDescriptions, armorDescriptions, magicTitles, magicDescriptions;
    public Sprite[] weaponImages, armorImages, magicImages;
}

