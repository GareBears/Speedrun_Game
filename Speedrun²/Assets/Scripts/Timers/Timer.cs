using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public float savedtime;
    public TMP_Text timerText;

    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        timerIsRunning = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void TimeLoop()
    {
        savedtime = (int)timeRemaining;
        gameManager.UpdateScore(savedtime);
        timeRemaining = 100f;
    }

    public void TimeStart()
    {
        timerIsRunning = true;
        timerText.gameObject.SetActive(true);
    }

    public void TimeStop()
    {
        timerIsRunning = false;
        timerText.gameObject.SetActive(false);
    }

    public void powerTime()
    {
        timeRemaining = timeRemaining + 30f;
    }


    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            //else
            //{
                //Debug.Log("Time has run out!");
                //timeRemaining = 0;
                //timerIsRunning = false;
           // }
        }

        //if(timeRemaining < 0)
        //{
            //timeRemaining = 0;
        //}
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
