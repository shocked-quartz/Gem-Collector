using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehavior : MonoBehaviour
{
    public AudioClip collectSound;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("COLLECTED");
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            if (Time.timeSinceLevelLoad < GameObject.Find("LevelManager").GetComponent<GameManager>().levelTime / 2)
            {
                GameManager.score += 2;
            }
            else
            {
                GameManager.score++;
            }
            GameManager.gemsRemaining--;
            Destroy(gameObject, 0.7f);
        }
    }
}
