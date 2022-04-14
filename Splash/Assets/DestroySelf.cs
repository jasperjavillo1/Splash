using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    //parameters
    [SerializeField] float _timeTillDestroy = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _timeTillDestroy);
    }
}
