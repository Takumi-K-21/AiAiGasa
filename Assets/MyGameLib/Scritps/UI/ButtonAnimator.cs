// ==================================================
// ButtonAnimator.cs
// ボタンのアニメーションを管理するクラス
// 動作確認 Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;
using UnityEngine.EventSystems;

namespace MyGameLib.UI
{
    public class ButtonAnimator : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        // ボタンのアニメーションを実装したクラス
        [SerializeField] private MonoBehaviour _buttonAnimationHandler;
        // ボタンのアニメーションのインターフェース
        private IButtonAnimation _buttonAnimation;

        // インターフェースを初期化
        private void Awake()
        {
            _buttonAnimation = _buttonAnimationHandler as IButtonAnimation;

#if UNITY_EDITOR
            if (_buttonAnimationHandler == null)
            {
                Debug.LogWarning(gameObject.name + "にButtonAnimationHandlerがありません", this);
            }

            if (_buttonAnimation == null)
            {
                Debug.LogWarning(gameObject.name + "のButtonAnimationHandlerにIButtonAnimationがありません", this);
            }
#endif
        }

        public void OnPointerUp(PointerEventData eventData) => _buttonAnimation?.OnPointerUp(eventData);
        public void OnPointerDown(PointerEventData eventData) => _buttonAnimation?.OnPointerDown(eventData);
        public void OnPointerEnter(PointerEventData eventData) => _buttonAnimation?.OnPointerEnter(eventData);
        public void OnPointerExit(PointerEventData eventData) => _buttonAnimation?.OnPointerExit(eventData);
    }
}
