using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 spawnValues;
    public int enemyForces;
    public float enemyDelay;
    public float startDelay;
    public float waveGap;

    public Text scoreText;
    private int score;
    public Text GameOverText;
    public Text RestartText;

    private bool gameOver;
    private bool restart;

    


    private void Start()
    {
        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("BattleFighter");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startDelay);
        while(true)
        {
            for (int i = 0; i < enemyForces; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(enemyDelay);
            }
            yield return new WaitForSeconds(waveGap);
            if(gameOver)
            {
                RestartText.text = "Press 'R' to restart!";
                restart = true;
                break;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }
	
}
