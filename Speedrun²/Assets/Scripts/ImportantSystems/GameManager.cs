using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    PlayerController JumpScriptB;

    public int Score;
    private int ScoreGoal = 250;
    
    public TMP_Text scoreText;
    public TMP_Text scoreLeft;
    public TMP_Text lvlTimer;
    public TMP_Text endTimer;
    public TMP_Text slowTimer;
    public TMP_Text FinalTime;

    public GameObject firstCamera;
    public GameObject titleScreen;
    public GameObject endScreen;
    public GameObject transScreen;
    public GameObject pauseButton;
    public GameObject instructScreen;


    //Timer Settings
    Timer TimeScriptA;
    FinalTimer TimeScriptB;
    SlowTimer SlowTimeScript;

    //Looping Settings
    Spawner LoopScript;

    public GameObject Button;
    public GameObject RestartButton;
    public GameObject GoBackButton;
    public GameObject HowtoButton;
    
    //////////////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        TimeScriptA = GameObject.FindGameObjectWithTag("TimerA").GetComponent<Timer>();
        TimeScriptB = GameObject.FindGameObjectWithTag("TimerB").GetComponent<FinalTimer>();
        LoopScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        SlowTimeScript = GameObject.FindGameObjectWithTag("TimerC").GetComponent<SlowTimer>();  
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    void Update()
    {
        JumpScriptB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (Input.GetKeyDown(KeyCode.O))
        {
            BeginGame();
        }

        if (ScoreGoal <= 0)
        {
            EndGame();
            TimeScriptB.ScoreCalc();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

       public void OnButtonClick()
    {
        BeginGame();
        Instantiate(Player);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    public void Restart()
    {
        Player.transform.position = new Vector3(0f, 0.01f, 0f);
        LoopScript.SpawnPlayer();
        TimeScriptA.TimeLoop();
        TimeScriptB.ScoreCalc();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    public void UpdateScore(float scoretoadd)
    {
        ScoreGoal -= (int)scoretoadd;
        scoreText.SetText(ScoreGoal.ToString());
    }

    public void FinalScore(float finalscore)
    {
        Score -= (int)finalscore;
    }

    public void PlayerJumpBoost()
    {
        JumpScriptB.JumpBoost();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    public void BeginGame()
    {
        TimeScriptA.TimeStart();
        TimeScriptB.TimeStartB();
        scoreText.SetText(ScoreGoal.ToString());
        scoreLeft.SetText("Score Left: ");
        Button.SetActive(false);
        firstCamera.SetActive(false);
        titleScreen.SetActive(false);
        transScreen.SetActive(true);
        pauseButton.SetActive(true);
        HowtoButton.SetActive(false);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    void EndGame()
    {
        endScreen.SetActive(true);
        transScreen.SetActive(false);
        RestartButton.SetActive(true);
        TimeScriptA.TimeStop();
        TimeScriptB.TimeStopB();
        pauseButton.SetActive(false);
        TimeScriptB.GetFinalTime();
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerSlow()
    {
        SlowTimeScript.TimeStart();
    }

    public void HowTo()
    {
        instructScreen.SetActive(true);
        titleScreen.SetActive(false);
        GoBackButton.SetActive(true);
        Button.SetActive(false);
        HowtoButton.SetActive(false);
    }

    public void DisplayFinalTime(float finaltime)
    {
        FinalTime.SetText("Final Time: " + finaltime);
    }
}