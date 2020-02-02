using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get { return _instance; }
        set { _instance = value; }
    }

    [SerializeField]
    private bool stageOne;

    public bool StageOne 
    {
        get { return stageOne; }
        set { stageOne = value; }
    }
    [SerializeField]
    private bool stageTwo;

    public bool StageTwo
    {
        get { return stageTwo; }
        set { stageTwo = value; }
    }
    public bool StageThree { get; set; }
    public bool StageFour { get; set; }
    public bool StageFive { get; set; }

    


    private void Awake ()
    {
        if (Instance == null) { Instance = this; }
    }
    public void StageOneCompleted ()
    {
        stageOne = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
