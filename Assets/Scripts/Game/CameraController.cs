using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _cameraTarget;
    [SerializeField] private float _lerpSpeed = 3f;

    private void Start()
    {
        transform.position = new Vector3(_cameraTarget.transform.position.x, transform.position.y, transform.position.z);

    }

    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(_cameraTarget.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, _lerpSpeed * Time.deltaTime);
    }
}
