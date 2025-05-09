// ==================================================
// ButtonAnimator.cs
// �{�^���̃A�j���[�V�������Ǘ�����N���X
// ����m�F Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;
using UnityEngine.EventSystems;

namespace MyGameLib.UI
{
    public class ButtonAnimator : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        // �{�^���̃A�j���[�V���������������N���X
        [SerializeField] private MonoBehaviour _buttonAnimationHandler;
        // �{�^���̃A�j���[�V�����̃C���^�[�t�F�[�X
        private IButtonAnimation _buttonAnimation;

        // �C���^�[�t�F�[�X��������
        private void Awake()
        {
            _buttonAnimation = _buttonAnimationHandler as IButtonAnimation;

#if UNITY_EDITOR
            if (_buttonAnimationHandler == null)
            {
                Debug.LogWarning(gameObject.name + "��ButtonAnimationHandler������܂���", this);
            }

            if (_buttonAnimation == null)
            {
                Debug.LogWarning(gameObject.name + "��ButtonAnimationHandler��IButtonAnimation������܂���", this);
            }
#endif
        }

        public void OnPointerUp(PointerEventData eventData) => _buttonAnimation?.OnPointerUp(eventData);
        public void OnPointerDown(PointerEventData eventData) => _buttonAnimation?.OnPointerDown(eventData);
        public void OnPointerEnter(PointerEventData eventData) => _buttonAnimation?.OnPointerEnter(eventData);
        public void OnPointerExit(PointerEventData eventData) => _buttonAnimation?.OnPointerExit(eventData);
    }
}
