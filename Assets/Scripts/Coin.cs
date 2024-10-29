using System;
using UnityEngine;

public class Coin : MonoBehaviour
{   private AudioSource audio;
    private CoinController controller;
    private Score score;
    private Transform endPointLeft;
    private Transform endPointRight;

    private void Start()
    {
        audio = GameObject.Find("CoinSound").GetComponent<AudioSource>();
        controller = GameObject.Find("CoinController").GetComponent<CoinController>();
        score = GameObject.Find("Score").GetComponent<Score>();
        endPointLeft = GameObject.FindGameObjectWithTag("EndPointLeft").GetComponent<Transform>();
        endPointRight = GameObject.FindGameObjectWithTag("EndPointRight").GetComponent<Transform>();
    }
    void Update()
    {
        if (gameObject.tag == "Coin")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (3f * Time.deltaTime));
        }
        else if (gameObject.tag == "CoinDL")
        {
            transform.position = Vector2.MoveTowards(transform.position, endPointLeft.position, 3f * Time.deltaTime);
        }
        else if (gameObject.tag == "CoinDR")
        {
            transform.position = Vector2.MoveTowards(transform.position, endPointRight.position, 3f * Time.deltaTime);

        }
            
        
        
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Coin")
        {
            if (collision.gameObject.CompareTag("destroy"))
            {
           
                
                controller.SpawnObject();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
            
               
                controller.SpawnObject();
           
                score.PlusScore();
                audio.Play();
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "CoinDL" | gameObject.tag == "CoinDR")
        {
            if (collision.gameObject.CompareTag("destroy"))
            {
           
                
                controller.SpawnObject();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("PlayerD"))
            {
            
               
                controller.SpawnObject();
                score.PlusScore();
                audio.Play();
                Destroy(gameObject);
            }
            
        }
    }
}
