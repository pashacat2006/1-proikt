using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameData
{
    public Vector3 Position;
    public float Health;
}

public class save : MonoBehaviour
{
    private string _fileName = "MySave.pasha";

    private string _path;

    public GameData player;
    public GameObject playerg;
    public Image healch1;

    private void Start()
    {
        _path = Application.persistentDataPath + "/" + _fileName;
        print("Save path: " + _path);

        player = new GameData();
        Load();
    }

    public void Save()
    {
        player.Position = playerg.transform.position;
        player.Health = healch1.fillAmount;
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(_path, json);
    }

    public void Load()
    {
        string file = File.ReadAllText(_path);

        player = JsonUtility.FromJson<GameData>(file);
        playerg.transform.position = player.Position ;
        healch1.fillAmount = player.Health;
    }
}
