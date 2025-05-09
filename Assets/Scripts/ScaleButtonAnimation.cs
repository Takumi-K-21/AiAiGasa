using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using MyGameLib.Sound;
using MyGameLib.UI;

public class ScaleButtonAnimation : ButtonAnimationBase
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        SEManager.Instance.Play("Button");
        transform.DOScale(1f, 0.15f).SetEase(Ease.OutQuad);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(0.95f, 0.15f).SetEase(Ease.OutQuad);
    }

    public override void OnPointerEnter(PointerEventData eventData) { }

    public override void OnPointerExit(PointerEventData eventData) { }
}
