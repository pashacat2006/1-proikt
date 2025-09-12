using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData
{
    public Vector3 Position;
    public float Health;
}

public class save : MonoBehaviour
{
    private string _fileName = "MySave.cat";

    private string _path;

    public GameData player;

    private void Start()
    {
        _path = Application.persistentDataPath + "/" + _fileName;
        print("Save path: " + _path);

        player = new GameData();

        player.Position = new Vector3(0, 10, 2);
        player.Health = 100;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(_path, json);
    }

    public void Load()
    {
        string file = File.ReadAllText(_path);

        player = JsonUtility.FromJson<GameData>(file);
    }
}
