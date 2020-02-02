using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float TimeRemaining;
    DeathClock GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = this.GetComponent<DeathClock>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemaining = GameManager.timeLeft;
        if(TimeRemaining<=0)
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
