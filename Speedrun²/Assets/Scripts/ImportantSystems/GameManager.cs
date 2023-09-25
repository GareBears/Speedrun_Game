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
    private int ScoreGoal = 200;
    //private float slowtimer = 0.0f;
    //private float slowtime = 3.0f;

    public TMP_Text scoreText;
    public TMP_Text scoreLeft;
    public TMP_Text lvlTimer;
    public TMP_Text endTimer;
    public TMP_Text slowTimer;

    public GameObject firstCamera;
    public GameObject titleScreen;
    public GameObject endScreen;
    public GameObject transScreen;


    //Timer Settings
    Timer TimeScriptA;
    FinalTimer TimeScriptB;
    SlowTimer SlowTimeScript;

    //Looping Settings
    Spawner LoopScript;

    public GameObject Button;
    public GameObject RestartButton;
    
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
        //Debug.Log("TELEPORTIN TIME");
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
        //Player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 100);
        //Debug.Log("This kinda works");
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
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    void EndGame()
    {
        endScreen.SetActive(true);
        transScreen.SetActive(false);
        RestartButton.SetActive(true);
        TimeScriptA.TimeStop();
        TimeScriptB.TimeStopB();

        if(Score < 100)
        {
            Debug.Log("You Won");
        }
        else
        {
            Debug.Log("Do Better");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerSlow()
    {
        SlowTimeScript.TimeStart();
        //slowtimer -= Time.deltaTime;
        //slowTimer.text = Mathf.RoundToInt(slowtimer).ToString();
    }
}