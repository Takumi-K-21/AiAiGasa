using UnityEngine;

public class GirlfriendController : MonoBehaviour
{
    private float _maxMoveSpeed;
    private float _currentMoveSpeed;
    private Vector3 _direction;

    private void Awake()
    {
        _direction.x = 1f;
    }

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Play) return;

        _currentMoveSpeed = Random.Range(0f, _maxMoveSpeed);
        transform.position += _currentMoveSpeed * _direction * Time.deltaTime;
    }

    public void SetMaxMoveSpeed(float maxMoveSpeed)
    {
        _maxMoveSpeed = maxMoveSpeed;
    }
}
