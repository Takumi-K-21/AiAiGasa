using UnityEngine;
using MyGameLib.Sound;

public class RainDrop : PooledObject
{
    private float _speed;
    private Vector3 _direction;

    private PooledObject _pooledObject;

    private void Awake()
    {
        _pooledObject = GetComponent<PooledObject>();
    }

    public void Initialize(float speed, Vector2 direction)
    {
        _speed = speed;
        _direction = direction.normalized;

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    private void Update()
    {
        transform.position += _speed * _direction * Time.deltaTime;

        if (transform.position.y <= -7.5f) Release();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.State != GameState.Play) return;

        if (other.CompareTag("Girlfriend"))
        {
            GameManager.Instance.SetScore(10);
            SEManager.Instance.Play("Raindrop");
        }

        Release();
    }
}
