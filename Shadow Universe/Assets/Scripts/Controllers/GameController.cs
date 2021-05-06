using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private const string fileName = "ShadowUniverseData";
    private SaveData data = new SaveData();
    void Start()
    {
        data = new SaveData();
        if (SaveSystem.SaveExists(fileName))
        {
            data = SaveSystem.LoadData<SaveData>(fileName);
            print("loaded");
        }
    }

    public float saveTimer;
    void Update()
    {
        saveTimer += Time.deltaTime * (1 / Time.timeScale);
        if (saveTimer >= 15)
        {
            SaveSystem.SaveData(data, fileName);
            saveTimer = 0;
            print("saved");
        }
    }
}
