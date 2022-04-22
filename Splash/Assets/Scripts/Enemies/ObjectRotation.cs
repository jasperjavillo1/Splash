using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float floatstrength = 1;
    public float direction = -75;

    void Update()
    {
        transform.Rotate(0, 0, direction * Time.deltaTime * floatstrength); //rotates 50 degrees per second around z axis
    }
}
