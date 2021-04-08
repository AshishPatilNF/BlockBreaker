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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthUnits, minClamp, maxClamp), transform.position.y);
    }
}
