using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //Text 
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text hardModeText;
    public Text timeText;

    private int score;
    private int hazardHard;
    private bool gameOver;   // all of the bools are to make things easier when switching modes
    private bool restart;
    public bool hardMode;
    private bool timeMode;
    public bool endTime;
    public bool wMusicStart;
    public bool lMusicStart;

    private AudioSource audioSource;

    //Time Settings
    private float timer = 10.0f;
    
    void Start()
    {
        gameOver = false;
        restart = false;
        wMusicStart = false;
        lMusicStart = false;
        hardMode = false;
        timeMode = false;
        endTime = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        hardModeText.text = "Press 'H' for Hard Mode";
        timeText.text = "Press 'T' for Time Attack";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
      
    }

    private void Update()
    {
    if (restart)
        {
            if (Input.GetKeyDown (KeyCode.L))
            {
                SceneManager.LoadScene("Space Shooter"); // or whatever the name of your scene is
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            hazardHard = hazardCount * 2;
            hazardCount = hazardHard;
            hardMode = true;
            timeMode = false;
            hardModeText.text = "";
            timeText.text = "";
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            timeMode = true;
            hardModeText.text = "";
            hardMode = false;
            score = 0;
            UpdateScore();
        }

        if (timeMode == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0.00f;
                endTime = true;
                score = score + 0;
                UpdateScore();
            }
            timeText.text = timer.ToString("F");
        }

            if (Input.GetKey("escape"))
            Application.Quit();

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'L' Try Again";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (timeMode == false)
        {
            if (hardMode == false)
            {
                if (score >= 100)

                {
                    winText.text = "You win!";
                    gameOverText.text = "GAME CREATED BY STEPHEN BECK";
                    gameOver = true;
                    restart = true;
                    wMusicStart = true;
                    audioSource.Stop();
                }
            }
            if (hardMode == true)
            {
                if (score >= 300)

                {
                    winText.text = "You win!";
                    gameOverText.text = "GAME CREATED BY STEPHEN BECK";
                    hardModeText.text = "";
                    timeText.text = "";
                    gameOver = true;
                    restart = true;
                    wMusicStart = true;
                    audioSource.Stop();
                }
            }
        }
        if (timeMode == true)
        {
            if (timer <= 0)
            {
                winText.text = "Score: " + score;
                gameOverText.text = "GAME CREATED BY STEPHEN BECK";
                gameOver = true;
                restart = true;
                wMusicStart = true;
                audioSource.Stop();
            }
        }
    }
    public void GameOver()
    {
        if (timeMode == false)
        {
            gameOverText.text = "Game Over!";
            hardModeText.text = "";
            timeText.text = "";
            gameOver = true;
            lMusicStart = true;
            audioSource.Stop();
        }

        if (timeMode == true)
        {
            gameOverText.text = "Score: " + score;
            hardModeText.text = "";
            timeText.text = "";
            timeMode = false;
            gameOver = true;
            lMusicStart = true;
            audioSource.Stop();
        }
    }
}