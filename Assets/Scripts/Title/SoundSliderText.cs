using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundSliderText : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    private TextMeshProUGUI _valueText;

    private void Awake()
    {
        _valueText = GetComponent<TextMeshProUGUI>();
        _soundSlider.onValueChanged.AddListener(SetValueText);
    }

    private void SetValueText(float value)
    {
        _valueText.text = (value * 100f).ToString("F0");
    }
}
