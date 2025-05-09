using UnityEngine;
using UnityEngine.UI;
using MyGameLib.Sound;

public class BGMVolumeSlider : MonoBehaviour
{
    private Slider _bgmVolumeSlider;

    private void Awake()
    {
        _bgmVolumeSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        BGMManager.Instance.SetVolume(_bgmVolumeSlider.value);
        _bgmVolumeSlider.onValueChanged.AddListener(BGMManager.Instance.SetVolume);
    }
}
