using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    
    public static int bestScore = 0;

    void Awake()
    {
        if (scoreManager != null)
        {
            Destroy(gameObject);
            return;
        }

        scoreManager = this;
        DontDestroyOnLoad(gameObject);

        
    }

}
