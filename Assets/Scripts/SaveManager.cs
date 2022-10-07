using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveScriptableObject saveScriptableObject;

    public Level level;
    
    void Start()
    {
        instance = this;

        level = new Level(1, LevelUp);
        Load();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.sav";

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            level.AddExp((int)GameMaster.instance.experience);

            SaveObject data = new SaveObject
            {
                curLevel = level.currentLevel,
                curXP = level.experience,
                maxXP = level.MAX_EXP,
                credits = (int)saveScriptableObject.coins,
                skinIndex = saveScriptableObject.skinIndex,
            };

            formatter.Serialize(stream, data);
        };
    }

    public SaveObject Load()
    {
        string path = Application.persistentDataPath + "/save.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Debug.Log(path);

            if(stream.Length == 0)
            {
                Debug.Log("Save is empty");
            }

            SaveObject data = formatter.Deserialize(stream) as SaveObject;

            level.currentLevel = data.curLevel;
            level.experience = data.curXP;
            level.MAX_EXP = data.maxXP;
            saveScriptableObject.coins = data.credits;
            saveScriptableObject.skinIndex = data.skinIndex;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public void LevelUp()
    {
        saveScriptableObject.coins += 500;
        Save();
    }


    [System.Serializable]
    public class SaveObject
    {
        //Money
        public int credits;

        //Level
        public int curLevel;
        public int curXP;
        public int maxXP;

        //Skins
        public int skinIndex;
    }
}
