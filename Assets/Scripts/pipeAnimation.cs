using System.Collections;
using UnityEngine;

public class pipeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Bomb;
    [SerializeField] private GameObject Present;
    [SerializeField] private AudioSource BombSound;
    [SerializeField] private AudioSource PipeSound;
    [SerializeField] private AudioSource PresentSound;
    [SerializeField] private GameObject[] PipeSmoke;
    public static CoinController _coinController;
    
    

    // Update is called once per frame
    private void Start()
    {
        _coinController = GameObject.Find("CoinController").GetComponent<CoinController>();
        PipeSound = GameObject.Find("PipeSound").GetComponent<AudioSource>();
        BombSound = GameObject.Find("BombSound").GetComponent<AudioSource>();
        PresentSound = GameObject.Find("PresentSound").GetComponent<AudioSource>();
        /*PipeSmoke = GameObject.FindGameObjectsWithTag("pipeSmoke");*/
       
    }

    public void spawnDrops()
    {
        if (_coinController.dropIndex == 0)
        {
            if (_coinController.randomNumber == 2 )
            {
                Instantiate(Coin, _coinController.position);
                PipeSound.Play();
                GameObject.Find("coin(Clone)").tag = "CoinDL";
            }
            else if (_coinController.randomNumber == 3)
            {
                Instantiate(Coin, _coinController.position);
                PipeSound.Play();
                GameObject.Find("coin(Clone)").tag = "CoinDR";
            }
            else if (_coinController.randomNumber == 4)
            {
                Instantiate(Bomb, _coinController.position);
                GameObject.Find("Bomb(Clone)").tag = "BombC";
                Bombsound();
            }
            else
            {
                Instantiate(Coin, _coinController.position );
                PipeSound.Play();
                GameObject.Find("coin(Clone)").tag = "Coin";
            }
        }
        
        else if (_coinController.dropIndex == 1)
        {
            if (_coinController.randomNumber == 2 )
            {
                Instantiate(Bomb, _coinController.position);
                GameObject.Find("Bomb(Clone)").tag = "BombDL";
                Bombsound();
            }
            else if (_coinController.randomNumber == 3)
            {
                Instantiate(Bomb, _coinController.position);
                GameObject.Find("Bomb(Clone)").tag = "BombDR";
                Bombsound();
            }
            else if (_coinController.randomNumber == 4)
            {
                Instantiate(Bomb, _coinController.position);
                GameObject.Find("Bomb(Clone)").tag = "BombC";
                Bombsound();
            }
            else
            {
                Instantiate(Bomb, _coinController.position);
                GameObject.Find("Bomb(Clone)").tag = "Bomb";
                Bombsound();
            }
        }
        else
        {
            if (_coinController.randomNumber == 2 )
            {
                Instantiate(Present, _coinController.position);
                GameObject.Find("present(Clone)").tag = "PresentDL";
                Presentsound();
            }
            else if (_coinController.randomNumber == 3)
            {
                Instantiate(Present, _coinController.position);
                GameObject.Find("present(Clone)").tag = "PresentDR";
                Presentsound();
            }
            else if (_coinController.randomNumber == 4)
            {
                Instantiate(Bomb, _coinController.position);
                GameObject.Find("Bomb(Clone)").tag = "BombC";
                Bombsound();
            }
            else
            {
                Instantiate(Present, _coinController.position);
                GameObject.Find("present(Clone)").tag = "Present";
                Presentsound();
            }
        }
    }
    
    public IEnumerator PipeExplode()
    {
        Fire.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Fire.SetActive(false);
        
    } 
    public void _pipeSmoke()
    { 
        PipeSmoke[_coinController.randomNumber].SetActive(true);
    }

    private void Bombsound()
    {
        PipeSound.Play();
        BombSound.Play();
    }

    private void Presentsound()
    {
        PresentSound.Play();
        PipeSound.Play();
    }
}
