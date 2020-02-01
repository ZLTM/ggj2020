using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpPosition : MonoBehaviour {
    public Transform objectToOrbit; //Object To Orbit
    Vector3 orbitAxis = Vector3.up; //Which vector to use for Orbit
    float orbitRadius = 35.0f; //Orbit Radius
    float orbitRadiusCorrectionSpeed = 0.5f; //How quickly the object moves to new position
    float orbitRoationSpeed = 30.0f; //Speed Of Rotation arround object
    //public float OrbitRoationSpeed { get; set; }
    float orbitAlignToDirectionSpeed = 0.5f; //Realign speed to direction of travel

    private Vector3 orbitDesiredPosition;
    private Vector3 previousPosition;
    private Vector3 relativePos;
    private Quaternion rotation;
    private Transform thisTransform;
    void Start () {
        thisTransform = transform;
    }

    void Update () {

        if (orbitRadius <= 0f) {
            orbitRadius = 0f;
        } else {
            orbitRadius -= 0.01f;
        }

        thisTransform.RotateAround (objectToOrbit.position, orbitAxis, orbitRoationSpeed * Time.deltaTime);
        orbitDesiredPosition = (thisTransform.position - objectToOrbit.position).normalized * orbitRadius + objectToOrbit.position;
        thisTransform.position = Vector3.Slerp (thisTransform.position, orbitDesiredPosition, Time.deltaTime * orbitRadiusCorrectionSpeed);

        //Rotation
        relativePos = thisTransform.position - previousPosition;
        rotation = Quaternion.LookRotation (relativePos);
        thisTransform.rotation = Quaternion.Slerp (thisTransform.rotation, rotation, orbitAlignToDirectionSpeed * Time.deltaTime);
        previousPosition = thisTransform.position;

        if (thisTransform.position.y > 1.0f) {
            thisTransform.position = new Vector3 (thisTransform.position.x, 1.0f, thisTransform.position.z);
        }
    }
}