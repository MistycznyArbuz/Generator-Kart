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
    public CardGenerator cardGenerator;
    public GameObject player;

    public string path, json;

    public Save savetest;

    private void Start()
    {
        //Ustawienie ścieżki
        path = Application.persistentDataPath;
    }

    public void GenerateButton()
    {
        cardGenerator.RandomCard();
    }

    public void SaveImage(Save save)
    {
        //Przechwytuje plik obrazka
        Sprite sprite = save.image = cardGenerator.actualCard.image.sprite;

        Texture2D texture = sprite.texture;

        byte[] imageBytes = texture.GetRawTextureData();

        File.WriteAllBytes(Application.persistentDataPath + "/Image.png", imageBytes);
    }

    public Sprite LoadImage()
    {
        //Odwrotna wersja SaveImage()
        byte[] imageBytes = File.ReadAllBytes(Application.persistentDataPath + "/Image.png");

        Texture2D texture = null;

        texture.LoadImage(imageBytes);

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    public Save SaveCard()
    {
        //Tworze nową instancje zapisu
        Save save = new Save();

        //Zapisuje dane do instancji zapisu
        save.title = cardGenerator.actualCard.title.text;
        save.description = cardGenerator.actualCard.descripton.text;

        SaveImage(save);

        save.cardEffect = cardGenerator.actualCard.cardEffect;

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
        json = File.ReadAllText(path + "/gamesave.json");

        savetest = new Save();

        savetest = JsonUtility.FromJson<Save>(json);

        cardGenerator.actualCard.title.text = savetest.title;
        cardGenerator.actualCard.descripton.text = savetest.description;
        cardGenerator.actualCard.image.sprite = savetest.image;
        cardGenerator.actualCard.cardEffect = savetest.cardEffect;

        Debug.Log("Gra wczytana");
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
        public string title, description;
        public Sprite image;
        public CardEffect cardEffect;
    }
}
