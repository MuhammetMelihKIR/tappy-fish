using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool gameStarted;
    public GameObject gameOverPanel;
    public GameObject getReady;
    public static int gameScore;
    public GameObject score;



    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        gameOver= false;    
        gameStarted= false;
    }
    public void GameHasStarted()
    {
        gameStarted= true;
        getReady.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        gameOver= true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore= score.GetComponent<Score>().GetScore();
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
