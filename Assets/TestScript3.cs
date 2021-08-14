using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript3 : MonoBehaviour
{
    public BallMoverScript ballMoverScript;

    private void Start()
    {
        ballMoverScript.ResetBall();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballMoverScript.LaunchBall();
        }
    }
}
