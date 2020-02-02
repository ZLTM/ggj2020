using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOne : MonoBehaviour
{
    HandleDificulty handleDificulty = new HandleDificulty();
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider userCollider)
    {
        Debug.Log("entro");
        handleDificulty.StageOne = true;
    }
}
