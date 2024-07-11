using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Character character;
    public ParticleSystem explode;
    public ParticleSystem explode1;
    public ParticleSystem explode2;
    public float respawnInstance = 3.0f;
    public float respawnTime = 3.0f;
    public int lives = 3;
    public int score = 0;
    public AudioSource c_audio;
    public Text scoreText;
    public Text livesText;
    public Text instructionsText;
    public Text cannonText;
    public GameObject gameOverPanel;
    public GameObject highScorePanel;
    public InputField highScoreInput;

    public GameObject meteor;
    public GameObject power;
    public GameObject addlives;

    public int numberOfMeteors;
    public int levelNumber = 1;
    public int scoreNumber = 0;
    public int livesNumber = 0;

    public Text highScoreText;

    public float messageDuration = 0.0f;

    private Queue<string> messageQueue = new Queue<string>();
    public bool isDisplaying = false;

    public void EnqueueMessage(string message)
    {
        messageQueue.Enqueue(message);
        if (!isDisplaying)
        {
            StartCoroutine(DisplayNextMessage());
        }
    }

    private IEnumerator DisplayNextMessage()
    {
        while (messageQueue.Count > 0)
        {
            isDisplaying = true;
            instructionsText.text = messageQueue.Dequeue();
            instructionsText.gameObject.SetActive(true);
            yield return new WaitForSeconds(messageDuration);
            instructionsText.gameObject.SetActive(false);
        }
        isDisplaying = false;
    }

        public void UpdateNumberOfMeteors(int change)
    {
        numberOfMeteors += change;

        if (numberOfMeteors <= 0){
            // Start new level
            Invoke("StartNewLevel", 3f);
        }
    }

    void StartNewLevel()
    {
        levelNumber++;

        //Spawn new asteroids
        for (int i = 0; i < levelNumber*2; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-15.7f,15.7f),12f);
            Instantiate(meteor, spawnPosition, Quaternion.identity);
            numberOfMeteors++;
        }
    }
    
    public void MeteorDestroyed(Meteor meteor)
    {
        this.explode.transform.position = meteor.transform.position;
        c_audio.Play();
        this.explode.Play();
        
        if (meteor.size < 0.75f) {
            this.score += 100;
        } else if (meteor.size < 1.2f)
        {
            this.score += 50;
        } else { 
            this.score += 25; 
        }

        scoreText.text = "Score " + score;
        EnqueueMessage(" Good job, shoot more asteroids ");
    }

    public void LivesDestroyed(AddLives addlives)
    {
        this.explode2.transform.position = addlives.transform.position;
        c_audio.Play();
        addlives.LivesObtained = true;
        EnqueueMessage(" Lives obtained ");
        this.lives++;
        livesText.text = " " + lives;
    }

        public void PowerDestroyed(Power power)
    {
        this.explode1.transform.position = power.transform.position;
        c_audio.Play();
        power.PowerObtained = true;
        EnqueueMessage("  Power obtained ");
        cannonText.text = " 3 Cannons Enabled ";
    }

    public void CharacterDied()
    {
        this.explode.transform.position = this.character.transform.position;
        c_audio.Play();
        this.explode.Play();
        EnqueueMessage("  Try again ");
        this.lives--;
        livesText.text = " " + lives;
        if (this.lives < 1)
        {
            GameisOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnInstance);
        }
    }

    private void Respawn()
    {
        this.character.transform.position = Vector3.zero;
        this.character.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.character.gameObject.SetActive(true);
        this.character.Invoke(nameof(TurnOnCollisions), this.respawnTime);
        EnqueueMessage("  Player respawned ");
    }

    private void TurnOnCollisions()
    {
        this.character.gameObject.layer = LayerMask.NameToLayer("Character");
    }
    private void GameisOver()
    {
        //Check for high scores
        if (HighScoreCheck(score))
        {
            highScorePanel.SetActive(true);
            EnqueueMessage("  Input name for new high score ");
        }
        else
        {
            gameOverPanel.SetActive(true);
            EnqueueMessage("  Try again, press play ");
        }

        highScoreText.text = "HIGH SCORES" + "\n" + "---------------------------------" + "\n" + "\n" + PlayerPrefs.GetString("highscoreName") + " " + PlayerPrefs.GetInt("highscore");

    }

    public void HighScoreInput()
    {
        string newInput = highScoreInput.text;
        Debug.Log(newInput);
        highScorePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        EnqueueMessage(" Try again, press play ");
        PlayerPrefs.SetString("highscoreName",newInput);
        PlayerPrefs.SetInt("highscore",score);
        highScoreText.text = "HIGH SCORE" + "\n" + "---------------------------------" + "\n" + "\n" + PlayerPrefs.GetString("highscoreName") + " " + PlayerPrefs.GetInt("highscore");
    }

    private bool HighScoreCheck(int playerscore)
    {
        //Check for high scores
        int HighScore = PlayerPrefs.GetInt("highscore");
        if (playerscore > HighScore) { 
            return true;
        }
        return false;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Meteors");
        EnqueueMessage(" Shoot the asteroids ");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Menu");
        EnqueueMessage(" Enter selection ");
    }
    public void ExitGame()
    {
        EnqueueMessage(" Exiting the game... ");
        Application.Quit();
    }

    void Start()
    {
        score = 0;
        
        scoreText.text = "Score " + score;
        livesText.text = " " + lives;
        EnqueueMessage("Use arrows keys to move, space bar to shoot");
        EnqueueMessage("Shoot the asteroids to score");
        cannonText.text = " Get 3 cannons ";
    }

}
