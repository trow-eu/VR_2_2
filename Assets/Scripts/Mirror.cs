﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform mirrorCam;
    public Transform playerCam;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Calculations()
    {
        Vector3 dir = (playerCam.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;

        mirrorCam.localRotation = rot;
    }
}
