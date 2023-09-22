using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalTimer : MonoBehaviour
{
    public float timeUp = 10;
    public bool timerIsRunning = false;
    public TMP_Text timerText;

    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        timerIsRunning = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void TimeStartB()
    {
        timerIsRunning = true;
        timerText.gameObject.SetActive(true);
    }

    public void ScoreCalc()
    {
        gameManager.FinalScore(timeUp);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if(timeUp > 0)
            {
                timeUp += Time.deltaTime;
                DisplayTime(timeUp);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeUp = 0;
                timerIsRunning = false;
            }
        } 
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
