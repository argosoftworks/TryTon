using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    CoinController controller;
    public TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _recordStart;
    [SerializeField] private TextMeshProUGUI _recordEnd;
    [SerializeField] private TextMeshProUGUI _currentScore;
    public int score = 0;
    

    private void Start()
    {
        controller = GameObject.Find("CoinController").GetComponent<CoinController>();
    }
    public void PlusScore()
    {
        score ++;
        _score.text = score.ToString();
    }

    public void PlusPresent()
    {
        score += 5;
        _score.text = score.ToString();
    }

    public void HighScore()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }
        _recordStart.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
        _recordEnd.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
        _currentScore.text = score.ToString();
    }

   
}
