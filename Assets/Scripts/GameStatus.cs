using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public float TimeRemaining;
    DeathClock deatchClock;
    completomostro fullMonster;
    GameObject BuildedMonster;
    float FogAdd;
    float FogLvl;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        deatchClock = this.GetComponent<DeathClock>();
        BuildedMonster = GameObject.Find("body");
        fullMonster = BuildedMonster.GetComponent<completomostro>();
    }

    // Update is called once per frame
    void Update()
    {
        FogLvl = RenderSettings.fogDensity;
        TimeRemaining = deatchClock.timeLeft;
        if (TimeRemaining <= 0)
        {
            Restart();
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