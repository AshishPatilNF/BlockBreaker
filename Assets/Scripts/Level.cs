using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Update is called once per frame
    void Update()
    {
        if(Bblocks == 0)
        {
            sceneLoading.LoadNextScene();
        }
    }

    public void AddBlocks()
    {
        Bblocks++;
    }

    public void RemoveBlock()
    {
        Bblocks--;
    }
}
