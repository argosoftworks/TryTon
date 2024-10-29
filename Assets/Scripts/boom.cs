using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boom : MonoBehaviour
{
    private Bomb bomb;

    private void Start()
    {
        bomb = GameObject.Find("Bomb(Clone)").GetComponent<Bomb>();
    }

    public void _boom()
    {
        Destroy(gameObject);
    }

   
    

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") | other.gameObject.CompareTag("PlayerD"))
        {
            bomb._gameOver();
        }
        else
        {
            controller.SpawnObject();
        }
    }*/
}
