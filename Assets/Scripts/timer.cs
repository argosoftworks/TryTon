using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private GameManager gameManager;
    
    #region Variables

    private TMP_Text _timerText;
    enum TimerType {Countdown, Stopwatch}
    [SerializeField] private TimerType timerType;

    

    private bool _isRunning;

    #endregion
    
    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
        gameManager = FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        if (!gameManager._gameStarted)
        {
            gameManager._timeToDisplay = 60.0f;
            return;
        }
        if (timerType == TimerType.Countdown && gameManager._timeToDisplay < 0.0f)
        {
            gameManager.TimeOut();
            return;
        }
        
        gameManager._timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(gameManager._timeToDisplay);
        _timerText.text = timeSpan.ToString(@"mm\:ss");

       
    }
}