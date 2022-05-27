using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text GameOverText;
    public int PlayerScore = 0;
    private AudioSource audioSource;
    public AudioListener audioListener;
    private DeathPlayer deathPlayer;
    public float TimeToDeath = 2f;
    private ShipControl shipControl;
    public Button ReloadGameBut;
    public Image ReloadGameIm;
    public float f0 = 0;
    public float death;
    void Start()
    {
        ReloadGameBut.enabled = false;
        ReloadGameIm.enabled = false;
        audioSource = GetComponent<AudioSource>();
        deathPlayer = GameObject.FindObjectOfType<DeathPlayer>();
        shipControl = GameObject.FindObjectOfType<ShipControl>(); 
    }
    public void AddScoreMeteor()
    {
        PlayerScore += 3;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostAddScoreMeteor()
    {
        PlayerScore += 6;
        scoreText.text = PlayerScore.ToString();
    }
    public void AddScoreAsteroid()
    {
        PlayerScore += 7;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostAddScoreAsteroid()
    {
        PlayerScore += 14;
        scoreText.text = PlayerScore.ToString();
    }
    public void AddScoreShootingSaucer()
    {
        PlayerScore += 7;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostAddScoreShootingSaucer()
    {
        PlayerScore += 14;
        scoreText.text = PlayerScore.ToString();
    }
    public void AddScoreShield()
    {
        PlayerScore += 5;
        scoreText.text = PlayerScore.ToString();
    }
    public void AddScoreBigSaucer()
    {
        PlayerScore += 10;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostAddScoreBigSaucer()
    {
        PlayerScore += 20;
        scoreText.text = PlayerScore.ToString();
    }
    public void AddScoreCrash()
    {
        PlayerScore += 10;
        scoreText.text = PlayerScore.ToString();
    }
    public void AddScoreTinyMeteor()
    {
        PlayerScore += 5;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostAddScoreTinyMeteor()
    {
        PlayerScore += 10;
        scoreText.text = PlayerScore.ToString();
    }
    public void BossAddScore()
    {
        PlayerScore += 50;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostBossAddScore()
    {
        PlayerScore += 100;
        scoreText.text = PlayerScore.ToString();
    }
    public void ThirdBossAddScore()
    {
        PlayerScore += 150;
        scoreText.text = PlayerScore.ToString();
    }
    public void SecondBossAddScore()
    {
        PlayerScore += 100;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostSecondBossAddScore()
    {
        PlayerScore += 200;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostThirdBossAddScore()
    {
        PlayerScore += 300;
        scoreText.text = PlayerScore.ToString();
    }
    public void AddScoreFlyingSaurce()
    {
        PlayerScore += 5;
        scoreText.text = PlayerScore.ToString();
    }
    public void BoostAddScoreFlyingSaurce()
    {
        PlayerScore += 10;
        scoreText.text = PlayerScore.ToString();
    }
    public void DecreasScoreBelow()
    {
        PlayerScore = PlayerScore - 5;
        scoreText.text = PlayerScore.ToString();
    }
    public void DecreasScoreBeyond()
    {
        PlayerScore--;
        scoreText.text = PlayerScore.ToString();
    }
    public void PlayerDied()
    {
        if (f0 == 1)
        {
            death += Time.deltaTime;
            if (death >= 1f)
            {
                GameOverText.enabled = true;
                ReloadGameBut.enabled = true;
                ReloadGameIm.enabled = true;
            }
        }
    }
    public void StopSounds()
    {
        if (AudioListener.pause == false)
            AudioListener.pause = true;
        if (AudioListener.pause == true)
            AudioListener.pause = false;
    }
    void Update()
    {
        if (shipControl.HP == 0)
        {
            f0 = 1;
        }
        PlayerDied();
    }
}
