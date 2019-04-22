using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerDelete : MonoBehaviour
{
    public GameController gameControllerObj;


    // Start is called before the first frame update
    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControllerObj.wMusicStart == true)
        {
            Destroy(gameObject);
        }

        if (gameControllerObj.endTime == true)
        {
            Destroy(gameObject);
        }
    }
}
