using UnityEngine;
using DG.Tweening;
using MyGameLib.Sound;

public class ResultUI : MonoBehaviour
{
    private RectTransform _resultUITransform;

    private void Awake()
    {
        gameObject.SetActive(false);
        _resultUITransform = GetComponent<RectTransform>();
        _resultUITransform.localScale = Vector3.zero;
    }

    public void Pop()
    {
        gameObject.SetActive(true);
        _resultUITransform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        SEManager.Instance.Play("Pop");
    }
}
