using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
       
    private bool m_GameOver = false;

    private void Start()
    {
        ScoreText.text = "Score: " + m_Points + " Name: " + PlayerNameManager.playerName;
        BestScoreText.text = "Best Scores:\n" + "Name: " + ScoreManager.bestPlayerName[0] + " Score: " + ScoreManager.bestScore[0] + "\n" + "Name: " + ScoreManager.bestPlayerName[1] + " Score: " + ScoreManager.bestScore[1] + "\n" + "Name: " + ScoreManager.bestPlayerName[2] + " Score: " + ScoreManager.bestScore[2] + "\n";

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = "Score: " + m_Points + " Name: " + PlayerNameManager.playerName;
    }

    private void BestScoreList()
    {
        for (int i = 0; i < ScoreManager.bestScore.Length; i++)
        {
            if (m_Points > ScoreManager.bestScore[i])
            {
                for (int j = ScoreManager.bestScore.Length - 1; j > i; j--)
                {
                    ScoreManager.bestScore[j] = ScoreManager.bestScore[j - 1];
                    ScoreManager.bestPlayerName[j] = ScoreManager.bestPlayerName[j - 1];
                }

                ScoreManager.bestScore[i] = m_Points;
                ScoreManager.bestPlayerName[i] = PlayerNameManager.playerName;

                return;
            }
        }
    }

    public void GameOver()
    {
        BestScoreList();

        BestScoreText.text = "Best Scores:\n" + "Name: " + ScoreManager.bestPlayerName[0] + " Score: " + ScoreManager.bestScore[0] + "\n" + "Name: " + ScoreManager.bestPlayerName[1] + " Score: " + ScoreManager.bestScore[1] + "\n" + "Name: " + ScoreManager.bestPlayerName[2] + " Score: " + ScoreManager.bestScore[2] + "\n";

        GameOverText.SetActive(true);
        m_GameOver = true;
    }

    public void ChangePlayerName()
    {
        SceneManager.LoadScene(0);
    }
}
