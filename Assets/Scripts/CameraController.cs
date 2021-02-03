﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 transformation;

    void Start()
    {
        transformation = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = transformation + (player.transform.position / 2);
    }
}
