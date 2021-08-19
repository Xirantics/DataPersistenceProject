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
        public int bestScoreOne;
        public int bestScoreTwo;
        public int bestScoreThree;

        public string bestPlayerNameOne;
        public string bestPlayerNameTwo;
        public string bestPlayerNameThree;
    }

    public static void SaveScores()
    {
        SaveData data = new SaveData();

        data.bestScoreOne = bestScore[0];
        data.bestScoreTwo = bestScore[1];
        data.bestScoreThree = bestScore[2];

        data.bestPlayerNameOne = bestPlayerName[0];
        data.bestPlayerNameTwo = bestPlayerName[1];
        data.bestPlayerNameThree = bestPlayerName[2];

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

            bestScore[0] = data.bestScoreOne;
            bestScore[1] = data.bestScoreTwo;
            bestScore[2] = data.bestScoreThree;

            bestPlayerName[0] = data.bestPlayerNameOne;
            bestPlayerName[1] = data.bestPlayerNameTwo;
            bestPlayerName[2] = data.bestPlayerNameThree;
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
