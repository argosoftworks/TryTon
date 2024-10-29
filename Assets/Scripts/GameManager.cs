using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameover;
    [SerializeField] private GameObject _gamestart;
    [SerializeField] private GameObject over;
    [SerializeField] private GameObject Score;
    [SerializeField] private GameObject ButtonPanel;
    [SerializeField] private GameObject GameOverLogo;
    [SerializeField] private GameObject TimeOutLogo;
    [SerializeField] private AudioSource BombSound;
    [SerializeField] private AudioSource PipeSound;
    [SerializeField] private AudioSource PresentSound;
    private CoinController controller;
    private CharController characterController;
    
    private Score score;
    public float _timeToDisplay; 
    public bool _gameStarted = false;
    // Start is called before the first frame update
    private void Start()
    {
        PipeSound = GameObject.Find("PipeSound").GetComponent<AudioSource>();
        BombSound = GameObject.Find("BombSound").GetComponent<AudioSource>();
        PresentSound = GameObject.Find("PresentSound").GetComponent<AudioSource>();
        controller = GameObject.Find("CoinController").GetComponent<CoinController>();
        characterController = GameObject.Find("Character").GetComponent<CharController>();
        score = GameObject.Find("Score").GetComponent<Score>();
        score.HighScore();
        
    }

   

    public void GameOver()
    {   
        over.SetActive(false);
        PipeSound.Stop();
        BombSound.Stop();
        PresentSound.Stop();
        _gameover.SetActive(true);
        GameOverLogo.SetActive(true);
        _gameStarted = false;
        controller.animator.SetTrigger("stop");
        score.HighScore();
        
    }

    public void TimeOut()
    {
        over.SetActive(false);
        PipeSound.Stop();
        BombSound.Stop();
        PresentSound.Stop();
        _gameover.SetActive(true);
        TimeOutLogo.SetActive(true);
        _gameStarted = false;
        controller.animator.SetTrigger("stop");
        score.HighScore();
    }

    public void GameStart()
    {
        _timeToDisplay = 60.0f;
        Score.SetActive(true);
        ButtonPanel.SetActive(true);
        over.SetActive(false);
        _gameStarted = true;
        _gamestart.SetActive(false);
        over.SetActive(false);
        controller.SpawnObject();
        GameOverLogo.SetActive(false);
        TimeOutLogo.SetActive(false);
        if (score.score != 0)
        {
            score.score = 0;
            score._score.text = score.score.ToString();
        }
    }

    public void GameReload()
    {
        _timeToDisplay = 60.0f;
        characterController.Reset();
        Score.SetActive(true);
        ButtonPanel.SetActive(true);
        over.SetActive(false);
        _gameover.SetActive(false);
        _gameStarted = true;
        controller.SpawnObject();
        score.HighScore();
        GameOverLogo.SetActive(false);
        TimeOutLogo.SetActive(false);
        if (score.score != 0)
        {
            score.score = 0;
            score._score.text = score.score.ToString();
        }
    }

    public void Boom()
    {
        Score.SetActive(false);
        ButtonPanel.SetActive(false);
        over.SetActive(true);
    }
}
