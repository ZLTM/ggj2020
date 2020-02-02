using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma : MonoBehaviour {
    public GameObject actual;
    public string tag;
    public completomostro ske;
    // Start is called before the first frame update

    void Start () {

    }

    private void OnTriggerEnter (Collider other) {
        if (actual == null) {
            if (other.CompareTag (tag)) {
                transform.GetComponent<BoxCollider> ().enabled = false;
                other.GetComponent<BoxCollider> ().enabled = false;
                actual = other.gameObject;
                other.transform.position = transform.position;
                other.transform.rotation = transform.rotation;
                other.GetComponent<Rigidbody> ().useGravity = false;
                other.GetComponent<Rigidbody> ().Sleep ();
                Destroy (other.GetComponent<Rigidbody> ());
                other.transform.SetParent (transform);
                ske.partes (other.gameObject);
                enabled = false;
            }
        }

    }

}