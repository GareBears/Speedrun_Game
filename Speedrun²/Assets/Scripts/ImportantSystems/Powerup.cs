using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    Timer timerScript;

    // Start is called before the first frame update
    void Start()
    {
        timerScript = GameObject.FindGameObjectWithTag("TimerA").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        timerScript.powerTime();
        Destroy(gameObject);
    }
}
