using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    public static string playerName;

    public static PlayerNameManager playerNameManager;

    private void Awake()
    {
        if (playerNameManager != null)
        {
            Destroy(gameObject);
            return;
        }

        playerNameManager = this;
        DontDestroyOnLoad(gameObject);
    }
}
