using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolita : MonoBehaviour
{
    public Transform target;
    float vel = 30f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, vel * Time.deltaTime);
    }
}
