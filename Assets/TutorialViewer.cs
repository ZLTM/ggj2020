using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TutorialViewer : MonoBehaviour
{
    public Image TutorialImage;
    public GameObject Player;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        TutorialImage.GetComponent<Image>().enabled = true;
        Player.GetComponent<FirstPersonController>().enabled = false;
        Enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            TutorialImage.GetComponent<Image>().enabled = false;
            Player.GetComponent<FirstPersonController>().enabled = true;
            Enemy.SetActive(true);
        }
    }
}
