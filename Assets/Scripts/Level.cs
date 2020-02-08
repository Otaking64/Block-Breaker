using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneloader;


    [SerializeField] int breakableBlocks;


    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }


    public void CountBreakableBlocks()
    {
        breakableBlocks++;

    }


    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
