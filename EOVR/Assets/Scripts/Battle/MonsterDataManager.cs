using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Resist
{
    Null,
    Resist,
    Normal = 2,
    Weak = 4,
}

[System.Serializable]
public class MonsterData
{
    public int nID;
    public string Name;
    public int Lv;
    public int Hp;
    public int Attack;
    public int Defense;
    public int Matk;
    public int Mdef;
    public int Exp;
    public Resist[] Weakness = new Resist[6];
    public Resist[] StatusEffect = new Resist[4];
}

public class MonsterDataManager : MonoBehaviour {
    string path;
    int monsterCount = 0;

    public Dictionary<int, MonsterData> monsters = new Dictionary<int, MonsterData>();

    static MonsterDataManager _instance;
    public static MonsterDataManager instance
    {
        get { return _instance; }
    }


    private void Awake()
    {
        SpawnManager spawnManager = GetComponent<SpawnManager>();
        monsterCount += spawnManager.normals.Length + spawnManager.bigs.Length + spawnManager.foes.Length + spawnManager.bosses.Length;       
    }

    private void Start()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        path = Application.streamingAssetsPath.Replace("StreamingAssets", "Json/") + "MonsterData.json.txt";

        string jsonString = System.IO.File.ReadAllText(path);
        string[] jsonStrings = jsonString.Split('}');

        for (int i = 0; i < monsterCount; i++)
        {
            jsonStrings[i] += "}";
            MonsterData monsterData = JsonUtility.FromJson<MonsterData>(jsonStrings[i]);
            monsters.Add(monsterData.nID, monsterData);
        }
    }
}
