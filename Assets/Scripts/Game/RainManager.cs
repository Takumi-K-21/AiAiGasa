using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _angleLerpSpeed = 1f;

    private float _rainSpeed;
    private float _rainRate;
    private float _rainAngleRange;

    private float _currentAngle = 0f;
    private float _targetAngle = 0f;


    [SerializeField] private Vector2 _spawnArea = new Vector2(20f, 10f);

    // 雨の角度制御
    [SerializeField] private float _angleChangeInterval = 1f; // 次の角度までの時間
    [SerializeField] private float _angleJitter = 50f;        // 角度変化の揺れ幅

    private float _angleTimer = 0f;
    private float _spawnTimer = 0f;

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Play) return;

        _angleTimer += Time.deltaTime;
        if (_angleTimer >= _angleChangeInterval)
        {
            float jitter = Random.Range(-_angleJitter, _angleJitter);
            float next = _currentAngle + jitter;
            _targetAngle = Mathf.Clamp(next, -_rainAngleRange, _rainAngleRange);

            _angleTimer = 0f;
        }

        _currentAngle = Mathf.LerpAngle(_currentAngle, _targetAngle, _angleLerpSpeed * Time.deltaTime);

        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _rainRate)
        {
            _spawnTimer = 0f;
            SpawnRain(_currentAngle);
        }
    }

    private void SpawnRain(float angle)
    {
        // 雨の角度を求める
        float rad = angle * Mathf.Deg2Rad;
        Vector2 rainDirection = new Vector2(Mathf.Sin(rad), -Mathf.Cos(rad)).normalized;

        // 雨の角度によって、速度を変える
        float dot = Vector2.Dot(rainDirection, Vector2.down);
        float speedAdjust = Mathf.Lerp(0.5f, 1.5f, (dot + 1f) / 2f);
        float newRainSpeed = _rainSpeed * speedAdjust;

        // カメラを中心にして雨の生成する位置を決める
        Vector3 center = _camera.transform.position;
        Vector2 spawnOffset = -rainDirection * (_spawnArea.y);
        float spread = Random.Range(-_spawnArea.x / 2f, _spawnArea.x / 2f);
        Vector3 perpendicular = new Vector3(-rainDirection.y, rainDirection.x, 0f);
        Vector3 offset = (Vector3)spawnOffset + perpendicular * spread;
        Vector3 rainPos = center + offset;
        rainPos.z = 0f;

        CreateRainDrop(rainPos, rainDirection, newRainSpeed);
    }

    private void CreateRainDrop(Vector3 pos, Vector2 dir, float speed)
    {
        GameObject rainDropObject = _objectPool.GetPooledObject().gameObject;
        RainDrop rainDrop = rainDropObject.GetComponent<RainDrop>();
        rainDrop.transform.position = pos;
        rainDrop.Initialize(speed, dir);
    }

    public void SetRainDrop(float speed, float rate, float angle)
    {
        _rainSpeed = speed;
        _rainRate = rate;
        _rainAngleRange = angle;
    }
}
