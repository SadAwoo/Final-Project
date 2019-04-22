using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMusic : MonoBehaviour
{
    public GameController gameControllerObj;
    private AudioSource loseMusic;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        loseMusic = GetComponent<AudioSource>();
        loseMusic.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameControllerObj.lMusicStart == true)
        {
            loseMusic.enabled = true;
            loseMusic.volume = 0.5f;
        }
    }
}