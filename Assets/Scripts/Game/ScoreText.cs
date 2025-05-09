using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void SetScoreText(int currentScore, int maxScore)
    {
        currentScore = Mathf.Clamp(currentScore, 0, maxScore);
        _scoreText.text = currentScore + " / " + maxScore;
    }
}
