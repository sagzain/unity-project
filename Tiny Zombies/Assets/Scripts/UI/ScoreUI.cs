using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _endGameText;


    // Start is called before the first frame update
    void Start()
    {
        _text.text = 0.ToString();
    }

    public void UpdateScore(int value)
    {
        int currentScore = int.Parse(_text.text);
        currentScore += value;

        _text.text = currentScore.ToString();
    }

    public void EndGameScore()
    {
        _endGameText.text = "Your score: " + _text.text;
        gameObject.SetActive(false);
    }
}
