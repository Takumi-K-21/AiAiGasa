using UnityEngine;
using UnityEngine.UI;
using MyGameLib.Sound;

public class SEVolumeSlider : MonoBehaviour
{
    private Slider _seVolumeSlider;

    private void Awake()
    {
        _seVolumeSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        SEManager.Instance.SetVolume(_seVolumeSlider.value);
        _seVolumeSlider.onValueChanged.AddListener(SEManager.Instance.SetVolume);
    }
}
