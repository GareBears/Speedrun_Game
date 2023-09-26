using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotate : MonoBehaviour
{
    [SerializeField]
    float rotatespeed;
    [SerializeField]
    Vector3 rotationFirection = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotatespeed * rotationFirection * Time.deltaTime);
    }
}
