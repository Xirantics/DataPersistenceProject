using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        for (int i = 0; i < bestScore.Length; i++)
        {
            bestScore[i] = 0;
            bestPlayerName[i] = "-";
        }
    }

}
