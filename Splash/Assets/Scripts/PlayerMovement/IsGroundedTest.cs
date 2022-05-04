using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedTest : MonoBehaviour
{
    public LayerMask _groundLayer;
    Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGrounded());
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        if(Input.GetButton("Fire1"))
        {
            rd.AddForce(Vector2.up);
        }
    }

    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector3 direction = Vector3.down;
        float distance = 1f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _groundLayer);
        if (hit.collider == null)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
}
