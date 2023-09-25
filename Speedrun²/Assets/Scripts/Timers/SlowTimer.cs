using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowTimer : MonoBehaviour
{
    public float timeRemaining = 4;
    public bool timerIsRunning = false;
    public float savedtime;
    public TMP_Text slowtimerText;

    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        timerIsRunning = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SlowTime()
    {

    }

    public void TimeStart()
    {
        timeRemaining = 4;
        timerIsRunning = true;
        slowtimerText.gameObject.SetActive(true);
    }

    public void TimeStop()
    {
        timerIsRunning = false;
        slowtimerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                TimeStop();
            }
        }

        if (timeRemaining < 1)
        {
            timeRemaining = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        slowtimerText.text = "" + (int)timeRemaining;
    }
}
