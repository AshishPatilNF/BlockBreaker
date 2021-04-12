using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    AudioClip blockSound;

    [SerializeField]
    GameObject particleVFX;

    private Level level;

    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.AddBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PreAndPostDestroy();
    }

    private void PreAndPostDestroy()
    {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        gameStatus.AddScore();
        level.RemoveBlock();
        GameObject particlevfx = Instantiate(particleVFX, transform.position, Quaternion.identity);
        Destroy(particlevfx, 2f);
        Destroy(this.gameObject);
    }
}
