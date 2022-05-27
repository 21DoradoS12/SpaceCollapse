using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CurrentTime : MonoBehaviour
{
    public float timeStart = 60f;
    public Text timerText;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        timerText.text = timeStart.ToString();
    }
    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        if (timeStart <= 0)
            gameManager.PlayerDied();

    }
}
