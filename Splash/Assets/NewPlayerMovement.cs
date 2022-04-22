using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float MS = 1;
    public float JF = 1;

    private Rigidbody2D _rigBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MS;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigBody.velocity.y) < 0.001f)
        {
            _rigBody.AddForce(new Vector2(0, JF), ForceMode2D.Impulse);
        }

    }
}
