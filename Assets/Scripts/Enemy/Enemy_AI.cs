using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed = 5;
    public int rotationSpeed;
    public int maxdistance;

    public Transform myTransform;
    void Awake()
    {
        myTransform = transform;
    }
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;

        maxdistance = 2;
    }

    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.red);
        Debug.Log(Vector3.Distance(target.position, myTransform.position));
        if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
        {
            Vector3 direction = target.position - this.transform.position;
            direction.y = 0;

        }
        if (Vector3.Distance(target.position, myTransform.position) < 20)
        {
            Vector3 direction = target.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            transform.position += (target.position - transform.position).normalized
                * moveSpeed * Time.deltaTime;
        }
    }
}
