using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

public class CountdownText : MonoBehaviour
{
    private TextMeshProUGUI _countdownText;

    private void Awake()
    {
        _countdownText = GetComponent<TextMeshProUGUI>();
    }

    public async UniTask CountStartAsync()
    {
        _countdownText.gameObject.SetActive(true);

        _countdownText.text = "READY?";

        await UniTask.Delay(1500);

        _countdownText.text = "GO!";

        await UniTask.Delay(500);

        _countdownText.gameObject.SetActive(false);
    }
}
