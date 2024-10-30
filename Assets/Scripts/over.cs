using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class over : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    public void overGame()
    {
        gameManager.GameOver();
    }
}
