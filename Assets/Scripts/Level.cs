using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private int Bblocks = 0;

    private SceneLoader sceneLoading; 

    // Start is called before the first frame update
    void Start()
    {
        sceneLoading = FindObjectOfType<SceneLoader>();
    }

    public void AddBlocks()
    {
        Bblocks++;
    }

    public void RemoveBlock()
    {
        Bblocks--;

        if (Bblocks == 0)
        {
            sceneLoading.LoadNextScene();
        }
    }
}
