using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public float TimeRemaining;
    DeathClock GameManager;
    float FogAdd;
    public bool WinState = false;
    public bool RestartState = false;
    public float FogLvl;
    public GameObject Enemy;
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
        if (TimeRemaining <= 0)
        {
            RestartState = true;
        }

        if (WinState == true)
        {
            Win();
        }

        if (RestartState == true)
        {
            Restart();
        }

        if (FogLvl >= 0.7)
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
        Enemy.SetActive(false);
        FogAdd += Time.deltaTime / 15000;
        RenderSettings.fogDensity += FogAdd;
    }
}