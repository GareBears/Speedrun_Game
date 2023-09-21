using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Player;

    public int Score;
    private int ScoreGoal = 200;

    public TMP_Text scoreText;
    public TMP_Text scoreLeft;
    public TMP_Text lvlTimer;
    public TMP_Text endTimer;

    public GameObject firstCamera;
    public GameObject titleScreen;


    //Timer Settings
    Timer TimeScriptA;
    FinalTimer TimeScriptB;

    public GameObject Button;
    
    //////////////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        TimeScriptA = GameObject.FindGameObjectWithTag("TimerA").GetComponent<Timer>();
        TimeScriptB = GameObject.FindGameObjectWithTag("TimerB").GetComponent<FinalTimer>();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    void Update()
    {
        if(ScoreGoal == 0)
        {
            EndGame();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

       public void OnButtonClick()
    {
        Instantiate(Player);
        BeginGame();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    //void Restart
    //{
        //Score = timeRemaining;
        //timeRemaining = 100
        //SpawnPlayer();
    //}

    //////////////////////////////////////////////////////////////////////////////////////////////

    public void BeginGame()
    {
        TimeScriptA.TimeStart();
        TimeScriptB.TimeStartB();
        scoreText.SetText(ScoreGoal.ToString());
        scoreLeft.SetText("Score Left: ");
        Debug.Log("Hello");
        Button.SetActive(false);
        firstCamera.SetActive(false);
        titleScreen.SetActive(false);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    void EndGame()
    {
        if(Score < 100)
        {
            Debug.Log("You Won");
        }
        else
        {
            Debug.Log("Do Better");
        }
    }
}