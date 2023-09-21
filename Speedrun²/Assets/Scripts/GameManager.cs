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

    //Looping Settings
    Spawner LoopScript;
    private Transform destination;

    public GameObject Button;
    
    //////////////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        TimeScriptA = GameObject.FindGameObjectWithTag("TimerA").GetComponent<Timer>();
        TimeScriptB = GameObject.FindGameObjectWithTag("TimerB").GetComponent<FinalTimer>();
        LoopScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        destination = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Transform>();
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
        BeginGame();
        Instantiate(Player);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////

    public void Restart()
    {
        Player.transform.position = new Vector3(0f, 0.01f, 0f);
        LoopScript.SpawnPlayer();
        Debug.Log("TELEPORTIN TIME");
    
        //Score = timeRemaining;
        //timeRemaining = 100;
    }

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