using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidBody3D;
    public Transform onhand;
    void Start()
    {
        rigidBody3D = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        rigidBody3D.useGravity = false;
        transform.position = onhand.position;
        transform.parent = GameObject.Find("Hand").transform;
    }
    void OnMouseUp()
    {
        this.transform.parent = null;
        rigidBody3D.useGravity = true;
    }
}
