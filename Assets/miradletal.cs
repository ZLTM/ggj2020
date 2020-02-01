﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miradletal : MonoBehaviour
{
    Camera camera;
    public ShaderEffect_BleedingColors sf_bleed;
    public ShaderEffect_CorruptedVram sf_corrupt;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, camera.nearClipPlane));
        if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 1000))
        {
            var obj = hit.transform.gameObject;
            Debug.Log(obj);
            mirando();
        }
        else
        {
            sin_mirar();
        }
    }
    public void mirando() {

        sf_bleed.intensity = 4;
        sf_bleed.shift = 4;
        sf_corrupt.shift = 4;
    }
    public void sin_mirar() {
        sf_bleed.intensity = 0;
        sf_bleed.shift = 0;
        sf_corrupt.shift = 0;
    }
}
