using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarStretch : MonoBehaviour
{
    public GameController gameControllerObj;

    private ParticleSystem ps;
    public float hSliderValue = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        if (gameControllerObj.wMusicStart == true)
        {
            if (hSliderValue <= 15)
            {
                hSliderValue += Time.deltaTime;
            }

        }
    }
}
