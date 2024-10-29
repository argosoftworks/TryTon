using System;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    private AudioSource audio;
    private AudioSource explodeSound;
    private CoinController controllerCoin; 
    private GameManager gameManager;
    private Transform endPointLeft;
    private Transform endPointRight;
    private boom boom;
    private CharController controllerChar;
    [SerializeField] private GameObject bombBoom;
    [SerializeField] private GameObject bomb;
    private Collider2D overCollider;
    private void Start()
    {
        audio = GameObject.Find("BombSound").GetComponent<AudioSource>();
        explodeSound = GameObject.Find("ExplodeSound").GetComponent<AudioSource>();
        controllerCoin = GameObject.Find("CoinController").GetComponent<CoinController>();
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
        endPointLeft = GameObject.FindGameObjectWithTag("EndPointLeft").GetComponent<Transform>();
        endPointRight = GameObject.FindGameObjectWithTag("EndPointRight").GetComponent<Transform>();
        
        controllerChar = GameObject.FindObjectOfType<CharController>();
        
    }
    void Update()
    {
        if (bomb.activeSelf)
        {
            if (gameObject.tag == "Bomb")
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - (3f * Time.deltaTime));
            }
            else if (gameObject.tag == "BombDL")
            {
                transform.position = Vector2.MoveTowards(transform.position, endPointLeft.position, 3f * Time.deltaTime);
            }
            else if (gameObject.tag == "BombDR")
            {
                transform.position = Vector2.MoveTowards(transform.position, endPointRight.position, 3f * Time.deltaTime);
            }
            else if (gameObject.tag == "BombC")
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - (5f * Time.deltaTime));

            }
        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Bomb" | gameObject.tag == "BombC")
        {
            if (collision.gameObject.CompareTag("explodeC"))
            {
                audio.Stop();
                explodeSound.Play();
                _explode();
                Instantiate(bombBoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
                

            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                audio.Stop();
                explodeSound.Play();
                _gameOver();
                Instantiate(bombBoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
                
            }
        }
        else if (gameObject.tag == "BombDL" | gameObject.tag == "BombDR")
        {
            if (collision.gameObject.CompareTag("explodeC"))
            {
                audio.Stop();
                explodeSound.Play();
                _explode();
                Instantiate(bombBoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
            else if (collision.gameObject.CompareTag("PlayerD"))
            {
                audio.Stop();
                explodeSound.Play();
                _gameOver();
                Instantiate(bombBoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    public void _destroy()
    {
        Destroy(gameObject);
        if (gameManager._gameStarted)
        {
            controllerCoin._generateIndex();
            controllerCoin.SpawnObject();
        }
       
    }

    public void _gameOver()
    {
        gameManager.Boom();
        gameManager._gameStarted = false;
    }
    private void _explode()
    {
        if (controllerCoin.randomNumber == 1 | controllerCoin.randomNumber == 2)
        {
            if (controllerChar.poses[0].activeSelf | controllerChar.poses[1].activeSelf | controllerChar.poses[2].activeSelf)
            {
                _gameOver();
            }
            else
            {
                controllerCoin.SpawnObject();
            }
        }
        else if (controllerCoin.randomNumber == 3 | controllerCoin.randomNumber == 0)
        {
            if (controllerChar.poses[0].activeSelf | controllerChar.poses[3].activeSelf | controllerChar.poses[4].activeSelf)
            {
                _gameOver();
            }
            else
            {
                controllerCoin.SpawnObject();
            }
        }
        else if (controllerCoin.randomNumber == 4)
        {
            if (controllerChar.poses[0].activeSelf)
            {
                _gameOver();
            }
            else
            {
                controllerCoin.SpawnObject();
            }
        }
    }
}
