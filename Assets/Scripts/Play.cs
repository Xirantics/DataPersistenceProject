using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public Text playerNameInput;

    public void StartGame()
    {
        PlayerNameManager.playerName = playerNameInput.text;

        SceneManager.LoadScene(1);
    }

}
