using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;// наш счетчик
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI livesText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public bool isGameActive;
    private float spawnRate = 1.0f;
    private int score;
    private int lives;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();// метод для паузи
        }

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)// цикла вайл який рандомно запускає наші обєкти
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           
        }
    }
    public void UpdateScore(int scoretoAdd)// метод добавляти очки до счетчика
    {
        score += scoretoAdd;
        
        scoreText.text = "Score:" + score;
    }
    public void UpdateLives(int livestoChange)// метод добавляти очки до счетчика
    {
        lives += livestoChange;
        livesText.text = "Lives:" + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);//метод для перезапуску гри
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;//коли закінчиться
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//метод щоб загрузити наш рестарт метод
    }
   public void StartGame(int difficulty)// ми зробили новий метод щоб гра запускалася після вибору рівня
   {
        isGameActive = true;// щоб розуміти коли розпочинається гра 
        score = 0;
     
        StartCoroutine(SpawnTarget());// запуск в певний проміжок часу
        spawnRate /= difficulty;// формула рівня складносіт щоб кульки вилітали частіше
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
    }
    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale=0;

        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
} 
