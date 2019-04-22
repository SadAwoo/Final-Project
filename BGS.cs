using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGS : MonoBehaviour
{
    public GameController gameControllerObj;
    public float scrollSpeed;
    public float tileSizeZ;
    private float onePoint;
    
    private Vector3 startPosition;
    private Vector3 temp;
    


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        onePoint = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (gameControllerObj.hardMode == false)
        {
            if (gameControllerObj.wMusicStart == true)
            {
                if (scrollSpeed >= -15)
                {
                    scrollSpeed -= Time.deltaTime;
                }
            }
        }

        if (gameControllerObj.hardMode == true)
        {
            if (gameControllerObj.wMusicStart == true)
            {
                if (scrollSpeed >= -15)
                {
                    scrollSpeed -= onePoint;
                }
            }
        }
    }
}
