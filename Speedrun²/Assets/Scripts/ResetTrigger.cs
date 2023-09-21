using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    GameManager SpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpawnScript.Restart();
        other.gameObject.transform.position = new Vector3(0f, 0.01f, 0f);
    }
}
