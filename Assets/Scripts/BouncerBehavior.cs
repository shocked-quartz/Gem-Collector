using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerBehavior : MonoBehaviour
{
    public float bounceAmount;
    float lerpSpeed = 2;
    Color color1 = new Color(0.9f, 0.1f, 0.1f, 1);
    Color color2 = new Color(0.9f, 0.9f, 0.1f, 1);
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time * lerpSpeed, 1));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.impulse * bounceAmount, ForceMode.Impulse);
        }
    }
}
