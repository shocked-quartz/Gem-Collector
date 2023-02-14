using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    public AudioClip die;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameOver)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("enemyDie");
            AudioSource.PlayClipAtPoint(die, Camera.main.transform.position);
            Destroy(gameObject, 0.4f);
        }
    }
}
