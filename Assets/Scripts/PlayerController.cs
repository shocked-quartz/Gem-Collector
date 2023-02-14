using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    Rigidbody rb;
    bool grounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(new Vector3(horizontal, 0f, vertical) * speed * 2);
        }
        else
        {
            rb.AddForce(new Vector3(horizontal, 0f, vertical) * speed);
        }

    }

    void Update()
    {
        if (Input.GetButton("Jump") && grounded)
        {
            grounded = false;
            rb.AddForce(new Vector3(0f, jumpHeight, 0f), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
        if (other.gameObject.CompareTag("Hazard"))
        {
            GameObject.Find("LevelManager").GetComponent<GameManager>().LevelLost();
            Destroy(gameObject);
        }
    }
}
