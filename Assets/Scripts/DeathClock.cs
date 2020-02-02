using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathClock : MonoBehaviour
{
    public float MaxTime = 60.0f;
    public float timeLeft;
    TutorialViewer tutorialViewer;

    // Start is called before the first frame update
    void Start()
    {
        tutorialViewer = this.GetComponent<TutorialViewer>();

        timeLeft = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (tutorialViewer.TutorialImage.GetComponent<Image>().enabled == true)
        {
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
        }


        else
        {
            //Debug.Log("OWO time");
        }
    }
}
