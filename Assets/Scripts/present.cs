using System;
using UnityEngine;

public class present : MonoBehaviour
{   private AudioSource audio;
    private CoinController controller;
    private Score score;
    private Transform endPointLeft;
    private Transform endPointRight;

    private void Start()
    {
        audio = GameObject.Find("PresentSound").GetComponent<AudioSource>();
        controller = GameObject.Find("CoinController").GetComponent<CoinController>();
        score = GameObject.Find("Score").GetComponent<Score>();
        endPointLeft = GameObject.FindGameObjectWithTag("EndPointLeft").GetComponent<Transform>();
        endPointRight = GameObject.FindGameObjectWithTag("EndPointRight").GetComponent<Transform>();
    }
    void Update()
    {
        if (gameObject.tag == "Present")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (3f * Time.deltaTime));
        }
        else if (gameObject.tag == "PresentDL")
        {
            transform.position = Vector2.MoveTowards(transform.position, endPointLeft.position, 3f * Time.deltaTime);
        }
        else if (gameObject.tag == "PresentDR")
        {
            transform.position = Vector2.MoveTowards(transform.position, endPointRight.position, 3f * Time.deltaTime);
        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Present")
        {
            if (collision.gameObject.CompareTag("destroy"))
            {
                controller._generateIndex();
                controller.SpawnObject();
                Destroy(gameObject);
                audio.Stop();
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
            
                controller._generateIndex();
                controller.SpawnObject();
           
                score.PlusPresent();
                audio.Stop();
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "PresentDL" | gameObject.tag == "PresentDR")
        {
            if (collision.gameObject.CompareTag("destroy"))
            {
           
                controller._generateIndex();
                controller.SpawnObject();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("PlayerD"))
            {
                controller._generateIndex();
                controller.SpawnObject();
                score.PlusPresent();
                audio.Stop();
                Destroy(gameObject);
            }
            
        }
    }
}
