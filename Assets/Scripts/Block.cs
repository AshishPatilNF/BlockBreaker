using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    AudioClip blockSound;

    [SerializeField]
    GameObject particleVFX;

    [SerializeField]
    private int blockHealth = 2;

    [SerializeField]
    Sprite[] sprite;

    private Level level;

    SpriteRenderer spriteRender;

    private GameStatus gameStatus;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();

        if (CompareTag("Breakable"))
        {
            level.AddBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
            if (blockHealth < 1)
            {
                PreAndPostDestroy();
            }
            else
            {
                spriteRender.sprite = sprite[blockHealth-1];
                blockHealth--;
            }
        }
    }

    private void PreAndPostDestroy()
    {
        gameStatus.AddScore();
        level.RemoveBlock();
        GameObject particlevfx = Instantiate(particleVFX, transform.position, Quaternion.identity);
        Destroy(particlevfx, 2f);
        Destroy(this.gameObject);
    }
}
