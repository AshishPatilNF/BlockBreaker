using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float screenWidthUnits = 16f;

    [SerializeField]
    float maxClamp = 15f;

    [SerializeField]
    float minClamp = 1f;

    private GameStatus gameStatus;

    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(XpositionCalc(), minClamp, maxClamp), transform.position.y);
    }

    public float XpositionCalc()
    {
        if (gameStatus.IsAutoPlayOn())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
