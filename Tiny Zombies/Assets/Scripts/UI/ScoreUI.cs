using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using DG.Tweening;

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

        transform.DOPunchScale(Vector3.one * 0.33f, 1);

        _text.text = currentScore.ToString();
    }

    public void EndGameScore()
    {
        _endGameText.text = "Your score: " + _text.text;
        gameObject.SetActive(false);
    }
}
