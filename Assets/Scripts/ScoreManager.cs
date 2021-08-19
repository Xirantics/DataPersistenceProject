using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    
    public static int[] bestScore = new int[3];

    public static string[] bestPlayerName = new string[3];

    void Awake()
    {
        if (scoreManager != null)
        {
            Destroy(gameObject);
            return;
        }

        scoreManager = this;
        DontDestroyOnLoad(gameObject);

        LoadScores();
    }

    // The SaveData class needs to be tagged as serialized to be converted in json format
    [System.Serializable]
    class SaveData
    {
        public int[] bestScore;

        public string[] bestPlayerName;
    }

    public static void SaveScores()
    {
        SaveData data = new SaveData();

        data.bestScore = bestScore;

        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;

            bestPlayerName = data.bestPlayerName;
        }

        else
        {
            for (int i = 0; i < bestScore.Length; i++)
            {
                bestScore[i] = 0;
                bestPlayerName[i] = "-";
            }
        }
    }

}
