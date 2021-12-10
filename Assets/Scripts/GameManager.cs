using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public CardGenerator cardGenerator = GameEvents.GiveCardGenerator();
    public GameObject player;

    private string path, json;

    void OnEnable()
    {
        GameEvents.OnSaveClicked += SaveToFile;
        GameEvents.OnUseClicked += UseCard;
    }

    void OnDisable()
    {
        GameEvents.OnSaveClicked -= SaveToFile;
        GameEvents.OnUseClicked -= UseCard;
    }

    private void Start()
    {
        //Ustawienie ścieżki
        path = Application.persistentDataPath;

        LoadGame();
    }

    public void SaveImage(Save save)
    {
        //Przechwytuje plik obrazka
        Sprite sprite = cardGenerator.actualCard.image.sprite;
        Texture2D texture = sprite.texture;
        byte[] imageBytes = texture.EncodeToPNG();

        File.WriteAllBytes(Application.persistentDataPath + "/Image.png", imageBytes);
    }

    public Sprite LoadImage()
    {
        //Odwrotna wersja SaveImage()
        byte[] imageBytes = File.ReadAllBytes(Application.persistentDataPath + "/Image.png");

        Texture2D texture = new Texture2D(512, 512);

        texture.LoadImage(imageBytes);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

        return sprite;
    }

    public Save SaveCard()
    {
        //Tworze nową instancje zapisu
        Save save = new Save();

        //Zapisuje dane do instancji zapisu
        save.title = cardGenerator.actualCard.title;
        save.description = cardGenerator.actualCard.descripton;

        //Zapisuje również zdjęcie
        SaveImage(save);

        if (cardGenerator.actualCard.cardEffect.type == CardEffect.CardType.Weapon)
        {
            save.type = "weapon";
            save.effectValue = cardGenerator.actualCard.cardEffect.attackSpeed;
        }
        else if (cardGenerator.actualCard.cardEffect.type == CardEffect.CardType.Armor)
        {
            save.type = "wearable";
            save.effectValue = cardGenerator.actualCard.cardEffect.hp;
        }
        else
        {
            save.type = "magic";
            save.effectValue = cardGenerator.actualCard.cardEffect.mana;
        }

        //zwracam gotowy zapis
        return save;
    }

    public void SaveToFile()
    {
        Save save = SaveCard();
        json = JsonUtility.ToJson(save);
        File.WriteAllText(path + "/gamesave.json", json);

        Debug.Log("Gra zapisana");
    }

    public void LoadGame()
    {
        if (File.Exists(path + "/gamesave.json"))
        {
            json = File.ReadAllText(path + "/gamesave.json");
            Save save = new Save();
            save = JsonUtility.FromJson<Save>(json);

            cardGenerator.actualCard.title = save.title;
            cardGenerator.actualCard.descripton = save.description;
            cardGenerator.actualCard.image.sprite = LoadImage();

            CardEffect effect = new CardEffect();

            cardGenerator.actualCard.cardEffect = effect;

            if (save.type == "weapon")
            {
                cardGenerator.actualCard.cardEffect = effect;
                effect.type = CardEffect.CardType.Weapon;
                effect.attackSpeed = (int)save.effectValue;
            }
            else if (save.type == "wearable")
            {
                cardGenerator.actualCard.cardEffect = effect;
                effect.type = CardEffect.CardType.Armor;
                effect.hp = (int)save.effectValue;
            }
            else
            {
                cardGenerator.actualCard.cardEffect = effect;
                effect.type = CardEffect.CardType.Magic;
                effect.mana = (int)save.effectValue;
            }

            Debug.Log("Gra wczytana");
        }
        else
        {
            cardGenerator.RandomCard();
            Debug.Log("Brak pliku zapisu, generuje nową kartę");
        }
    }

    public void UseCard()
    {
        player.GetComponent<Player>().playerStats.HP += cardGenerator.actualCard.cardEffect.hp;
        player.GetComponent<Player>().playerStats.Mana += cardGenerator.actualCard.cardEffect.mana;
        player.GetComponent<Player>().playerStats.AttackSpeed += cardGenerator.actualCard.cardEffect.attackSpeed;

        cardGenerator.RandomCard();
    }

    [System.Serializable]
    public class Save
    {
        public string title, description, type;
        public float effectValue;
    }
}
