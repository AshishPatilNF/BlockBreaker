using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Paddle paddle1;

    float initPosY;

    float xLaunch = 2f;

    float yLaunch = 15f;

    bool hasStarted = false;
 
    // Start is called before the first frame update
    void Start()
    {
        initPosY = transform.position.y - paddle1.transform.position.y;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            BallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xLaunch, yLaunch);
            GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    private void BallToPaddle()
    {
        transform.position = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + 0.47f);
    }
}
