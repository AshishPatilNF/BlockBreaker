using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Paddle paddle1;

    float xLaunch = 2f;

    float yLaunch = 15f;

    bool hasStarted = false;

    Rigidbody2D rigidBody;

    AudioSource audioSourceBall;

    private GameStatus gameStatus;
 
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        rigidBody = GetComponent<Rigidbody2D>();
        audioSourceBall = GetComponent<AudioSource>();
        rigidBody.simulated = false;
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
        if(Input.GetMouseButtonDown(0) || gameStatus.IsAutoPlayOn())
        {
            hasStarted = true;
            rigidBody.velocity = new Vector2(xLaunch, yLaunch);
            rigidBody.simulated = true;
        }
    }

    private void BallToPaddle()
    {
        transform.position = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + 0.47f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            audioSourceBall.Play();
            rigidBody.velocity += new Vector2(UnityEngine.Random.Range(0f,0.5f), UnityEngine.Random.Range(0f, 0.5f));
        }
    }
}
