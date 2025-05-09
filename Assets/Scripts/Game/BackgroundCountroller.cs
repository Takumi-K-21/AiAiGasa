using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.01f;

    [SerializeField] private GameObject _camera;
    [SerializeField] private Image _background;

    private Material _material;
    private Vector2 _offset;
    private Vector3 _prevCameraPos;

    private void Start()
    {
        _material = _background.material;
        _offset = _material.GetTextureOffset("_MainTex");

        _prevCameraPos = _camera.transform.position;
    }

    private void Update()
    {
        Vector3 cameraDeltaPos = _camera.transform.position - _prevCameraPos;

        _offset.x += cameraDeltaPos.x * _scrollSpeed;
        _material.SetTextureOffset("_MainTex", _offset);

        _prevCameraPos = _camera.transform.position;
    }
}

