using UnityEngine;

[System.Serializable]
public class RoundData
{
    [SerializeField] private float _roundTime;
    [SerializeField] private float _rainRate;
    [SerializeField] private float _rainSpeed;
    [SerializeField] private float _rainAngle;
    [SerializeField] private float _girlfriendMoveSpeed;

    public float RoundTime => _roundTime;
    public float RainRate => _rainRate;
    public float RainSpeed => _rainSpeed;
    public float RainAngle => _rainAngle;
    public float GirlfriendMoveSpeed => _girlfriendMoveSpeed;
}