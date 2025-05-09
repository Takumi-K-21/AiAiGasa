using UnityEngine;
using TMPro;

public class RoundText : MonoBehaviour
{
    private TextMeshProUGUI _roundText;

    private void Awake()
    {
        _roundText = GetComponent<TextMeshProUGUI>();
    }

    public void SetRoundText(int currentRound, int maxRound)
    {
        currentRound = Mathf.Clamp(currentRound, 1, maxRound);
        _roundText.text = "ROUND " + currentRound + " / " + maxRound;
    }
}
