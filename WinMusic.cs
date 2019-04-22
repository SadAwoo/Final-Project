using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour
{
    public GameController gameControllerObj;
    private AudioSource winMusic;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        winMusic = GetComponent<AudioSource>();
        winMusic.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameControllerObj.wMusicStart == true)
        {
            winMusic.enabled = true;
        }
    }
}
