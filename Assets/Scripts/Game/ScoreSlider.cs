using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 3f;
    private Slider _scoreSlider;
    private float _targetScore;

    private void Awake()
    {
        _scoreSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        _scoreSlider.value = Mathf.Lerp(_scoreSlider.value, _targetScore, _lerpSpeed * Time.deltaTime);
    }

    public void SetTargetScore(float score)
    {
        _targetScore = score;
    }
}
