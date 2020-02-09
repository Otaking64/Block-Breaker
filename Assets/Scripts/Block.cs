using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int maxHits;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;


    Level level;
    GameStatus gameStatus;


    [SerializeField] int timesHit;


    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            TriggerSparklesVFX();
            Destroy(gameObject, 0.2f);
            level.BlockDestroyed();
            gameStatus.AddToScore();
        }
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);

        Destroy(sparkles, 2f);

    }

}
