using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public float TimeRemaining;
    public float MaxTime = 60;
    DeathClock deatchClock;
    completomostro fullMonster;
    GameObject BuildedMonster;
    float FogAdd;
    float FogLvl;
    public GameObject Enemy;
    HandleDificulty handleDificulty;
    int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        deatchClock = this.GetComponent<DeathClock>();
        BuildedMonster = GameObject.Find("body");
        fullMonster = BuildedMonster.GetComponent<completomostro>();
        handleDificulty = GameObject.FindGameObjectWithTag("HandleDificult").GetComponent<HandleDificulty>();
    }

    // Update is called once per frame
    void Update()
    {
        FogLvl = RenderSettings.fogDensity;
        TimeRemaining = deatchClock.timeLeft;
        if (TimeRemaining <= 0)
        {
            difficulty++;
            if (difficulty == 1)
            {
                handleDificulty.EnterStageOne();
            }

            else if (difficulty == 2)
            {
                handleDificulty.EnterStageTwo();
            }

            else if (difficulty == 3)
            {
                handleDificulty.EnterStagetThree();
            }

        }

        if (fullMonster.completo == true)
        {
            Win();
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