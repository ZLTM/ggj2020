using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {
    public Transform target;
    public Transform jumpPosition;
    public float moveSpeed = 0.5f;
    public int rotationSpeed;
    public int maxdistance;
    public int mindistance;

    public Transform myTransform;

    private float nextActionTime = 3.0f;
    public float period = 0.1f;
    public float interval = 3.0f;
    void Awake () {
        myTransform = transform;
    }
    void Start () {
        GameObject go = GameObject.FindGameObjectWithTag ("Player");

        target = go.transform;

        mindistance = 2;
    }

    void Update () {
        Debug.DrawLine (target.position, myTransform.position, Color.red);
        if (Vector3.Distance (target.position, myTransform.position) > mindistance) {
            Vector3 direction = target.position - this.transform.position;
            direction.y = 0;

        }
        if (Vector3.Distance (target.position, myTransform.position) < maxdistance) {
            Vector3 direction = target.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
            transform.position += (target.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        if (Time.time > nextActionTime) {
            nextActionTime += period;
            Debug.Log ("como estamos");
            myTransform.position = jumpPosition.position;
            nextActionTime += interval;
        }
    }
}