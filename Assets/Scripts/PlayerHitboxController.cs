using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHitboxController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hitText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject hitImage;
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite[] healthBarSprites;

    AudioSource audioSource;

    [SerializeField] private AudioSource musicSource;

    [SerializeField] AudioClip hitSound, coinSound;

    private int timesHit = 0; 
    public int coinCounter = 0;

    public int obstaclesEvaded = 0;

    public int health = 3;

    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        coinText.text = "" + coinCounter;

        healthText.text = health.ToString();

        healthBar.sprite = healthBarSprites[health];

        hitText.text = "SCORE: " + obstaclesEvaded;

        highScoreText.text = "HIGH SCORE: " + highScore;

        if (obstaclesEvaded > highScore)
        {
            highScore = obstaclesEvaded;

            PlayerPrefs.SetInt("HighScore", obstaclesEvaded);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.transform.tag == "Projectile")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            timesHit++;

            ReduceHealth();

            if (PlayerPrefs.GetInt("vfxOff") == 0)
                audioSource.PlayOneShot(hitSound);

            hitImage.SetActive(false);
            hitImage.SetActive(true);
        }

        if(collision.transform.tag == "Coin")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);

            if (PlayerPrefs.GetInt("vfxOff") == 0)
                audioSource.PlayOneShot(coinSound);

            coinCounter++;            
        }
    }

    void ReduceHealth()
    {
        if(health > 0)
        {
            health--;
        }

        if(health <= 0)
        {         
            gameOverScreen.SetActive(true);

            musicSource.Stop();

            Time.timeScale = 0;
        }
    }
}
