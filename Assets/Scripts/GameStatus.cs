using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,10f)]
    private float GameTime = 1f;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private int points = 2;

    [SerializeField]
    private int score = 0;

    private bool autoPlayOn = true;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if(gameStatusCount > 1)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameTime;
    }

    public void AddScore()
    {
        score += points;
        text.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(this.gameObject);
    }

    public bool IsAutoPlayOn()
    {
        return autoPlayOn;
    }
}
