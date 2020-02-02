using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    float TimeRemaining;
    DeathClock GameManager;
    float FogAdd;
    public bool WinState = false;
    public float FogLvl;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = this.GetComponent<DeathClock>();
    }

    // Update is called once per frame
    void Update()
    {
        FogLvl = RenderSettings.fogDensity;
        TimeRemaining = GameManager.timeLeft;
        if(TimeRemaining<=0)
        {
            Restart();
        }

        if (WinState == true)
        {
            Win();
        }

        if (FogLvl >= 1.0)
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        FogAdd += Time.deltaTime/35000;
        RenderSettings.fogDensity += FogAdd;
    }
}
