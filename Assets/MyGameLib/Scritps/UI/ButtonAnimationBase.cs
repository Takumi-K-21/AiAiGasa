// ==================================================
// IButtonAnimation.cs
// 汎用的なボタンのアニメーションの基底クラス
// 動作確認 Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;
using UnityEngine.EventSystems;

namespace MyGameLib.UI
{
    public abstract class ButtonAnimationBase : MonoBehaviour, IButtonAnimation
    {
        protected virtual void Reset()
        {
            if (GetComponent<ButtonAnimator>() == null)
            {
                gameObject.AddComponent<ButtonAnimator>();
#if UNITY_EDITOR
                Debug.Log(gameObject.name + "にButtonAnimatorを追加しました", this);
#endif
            }
        }

        public abstract void OnPointerUp(PointerEventData eventData);
        public abstract void OnPointerDown(PointerEventData eventData);
        public abstract void OnPointerEnter(PointerEventData eventData);
        public abstract void OnPointerExit(PointerEventData eventData);
    }
}
