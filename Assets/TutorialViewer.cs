using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class TutorialViewer : MonoBehaviour
{
    public Image TutorialImage;
    DeathClock deatchClock;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Timer;
    TMP_Text TimeLeft;

    void Start()
    {
        TimeLeft = Timer.GetComponent<TMP_Text>();
        deatchClock = this.GetComponent<DeathClock>();

        TutorialImage.GetComponent<Image>().enabled = true;
        Player.GetComponent<FirstPersonController>().enabled = false;
        Enemy.SetActive(false);
    }

    void Update()
    {
        TimeLeft.text = deatchClock.timeLeft.ToString();

        if (Input.anyKeyDown)
        {
            TutorialImage.GetComponent<Image>().enabled = false;
            Player.GetComponent<FirstPersonController>().enabled = true;
            Enemy.SetActive(true);
        }
    }
}
