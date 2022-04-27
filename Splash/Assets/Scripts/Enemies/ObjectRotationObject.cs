﻿using UnityEngine;
using System.Collections;

public class ObjectRotationObject: MonoBehaviour
{

    public float speed;
    public Transform target;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    void FixedUpdate()
    {
        transform.RotateAround(target.position, zAxis, speed);
    }
}
