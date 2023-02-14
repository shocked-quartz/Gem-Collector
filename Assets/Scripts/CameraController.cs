using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraPos = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameOver)
        {
            transform.position = player.transform.position + cameraPos;
        }
    }
}
