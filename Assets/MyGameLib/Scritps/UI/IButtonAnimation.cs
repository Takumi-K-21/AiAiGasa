// ==================================================
// IButtonAnimation.cs
// �{�^���̃A�j���[�V�������Ǘ�����C���^�[�t�F�[�X
// ����m�F Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine.EventSystems;

namespace MyGameLib.UI
{
    public interface IButtonAnimation
    {
        void OnPointerUp(PointerEventData eventData);
        void OnPointerDown(PointerEventData eventData);
        void OnPointerEnter(PointerEventData eventData);
        void OnPointerExit(PointerEventData eventData);
    }
}
