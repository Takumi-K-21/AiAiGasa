using System.Collections.Generic;
using UnityEngine;
using MyGameLib.Sound;

public enum GameState
{
    Start,
    Play,
    Result
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState State { get; private set; }

    [SerializeField] private RainManager _rainManager;
    [SerializeField] private GirlfriendController _girlfriendController;
    [SerializeField] private GameObject _girlfriend;
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private RoundDataList _roundDataList;

    [SerializeField] private CountdownText _countdownText;
    [SerializeField] private ScoreSlider _scoreSlider;
    [SerializeField] private ScoreText _scoreText;
    [SerializeField] private RoundText _roundText;
    [SerializeField] private ResultText _resultText;
    [SerializeField] private ResultUI _resultUI;

    private int _currentRound = 0;
    private int _maxScore = 100;
    private int _currentScore = 0;

    private float _playTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        State = GameState.Start;
        _currentScore = _maxScore;
        _currentRound = 0;
        _playTime = 0f;
    }

    private async void Start()
    {
        _scoreSlider.SetTargetScore(_currentScore);
        _scoreText.SetScoreText(_currentScore, _maxScore);

        await _countdownText.CountStartAsync();

        State = GameState.Play;
        BGMManager.Instance.Play("Game");
        SetRoundSettings();
    }

    private void Update()
    {
        if (State == GameState.Play) Play();
    }

    private void Play()
    {
        if (IsGameOver())
        {
            _resultUI.Pop();
            State = GameState.Result;

            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            BGMManager.Instance.Stop();
            FadeManager.Instance.LoadScene("Game", 1f);
            State = GameState.Start;

            return;
        }

        _playTime += Time.deltaTime;

        if (_playTime >= _roundDataList.Round[_currentRound].RoundTime)
        {
            _playTime = 0f;
            _currentRound++;
            SetRoundSettings();
        }
    }

    private bool IsGameOver()
    {
        Vector3 pos = _mainCamera.WorldToViewportPoint(_girlfriend.transform.position);

        if (pos.x < 0 || pos.x > 1)
        {
            BGMManager.Instance.Play("Goodbye");
            _resultText.SetResultText("‚¶‚á‚ ‚Ì");
            return true;
        }

        if (_currentScore <= 0)
        {
            BGMManager.Instance.Play("Dislike");
            _resultText.SetResultText("‚í‚©‚ê");
            return true;
        }

        return false;
    }

    private void SetRoundSettings()
    {
        if (_currentRound >= _roundDataList.Count)
        {
            string resultText;
            string bgmName;

            if (_currentScore >= 90)
            {
                resultText = "‚¾‚¢‚·‚«";
                bgmName = "Like";
            }
            else if (_currentScore >= 70)
            {
                resultText = "‚·‚«";
                bgmName = "Like";
            }
            else if (_currentScore >= 50)
            {
                resultText = "‚Ó‚Â‚¤";
                bgmName = "Soso";
            }
            else if (_currentScore >= 30)
            {
                resultText = "‚«‚ç‚¢";
                bgmName = "Dislike";
            }
            else
            {
                resultText = "‚¾‚¢‚«‚ç‚¢";
                bgmName = "Dislike";
            }

            _resultText.SetResultText(resultText);
            BGMManager.Instance.Play(bgmName);

            _resultUI.Pop();
            State = GameState.Result;

            return;
        }

        RoundData roundData = _roundDataList.Round[_currentRound];
        _rainManager.SetRainDrop(roundData.RainSpeed, roundData.RainRate, roundData.RainAngle);
        _girlfriendController.SetMaxMoveSpeed(roundData.GirlfriendMoveSpeed);

        _roundText.SetRoundText(_currentRound + 1, _roundDataList.Count);
    }

    public void SetScore(int value)
    {
        _currentScore = Mathf.Max(_currentScore - value, 0);
        _scoreSlider.SetTargetScore(_currentScore);
        _scoreText.SetScoreText(_currentScore, _maxScore);
    }
}
