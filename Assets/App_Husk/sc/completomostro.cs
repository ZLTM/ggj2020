using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class completomostro : MonoBehaviour
{
    public bool completo;
    int partes_c = 0;
    Rigidbody mio_rig;
    public List<GameObject> obj = new List<GameObject>();
    // Start is called before the first frame update
    GameStatus gameStatus;
    AudioSource sonido;
    void Start()
    {
        mio_rig = GetComponent<Rigidbody>();
        gameStatus = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStatus>();
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void partes(GameObject x)
    {

        partes_c = partes_c + 1;
        obj.Add(x);
        if (partes_c >= 6)
        {
            completo = true;
            gameStatus.Win();
            vida_itsalife();

            foreach (var item in obj)
            {
                //   item.GetComponent<BoxCollider>().enabled=true;
            }
        }
    }
    public void vida_itsalife()
    {
        sonido.Play();
        GetComponent<BoxCollider>().enabled = true;
        mio_rig.isKinematic = false;
        mio_rig.useGravity = true;
        // mio_rig.AddForce(Vector3.forward*455,ForceMode.Force);

    }
}