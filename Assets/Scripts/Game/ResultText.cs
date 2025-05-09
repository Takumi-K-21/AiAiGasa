using UnityEngine;
using TMPro;

public class ResultText : MonoBehaviour
{
    private TextMeshProUGUI _resultText;

    private void Awake()
    {
        _resultText = GetComponent<TextMeshProUGUI>();
    }

    public void SetResultText(string resultText)
    {
        _resultText.text = resultText;
    }
}
