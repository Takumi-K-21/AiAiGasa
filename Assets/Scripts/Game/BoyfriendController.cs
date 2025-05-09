using UnityEngine;
using UnityEngine.InputSystem;

public class BoyfriendController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Vector3 _direction;

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Play) return;

        transform.position += _moveSpeed * _direction * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction.x = context.ReadValue<float>();
    }
}