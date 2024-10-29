using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    [SerializeField] private GameObject startGamePanel;
    [SerializeField] private GameObject gameOverPanel;

    public void NewGame()
    {
        startGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }
}
