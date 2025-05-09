// ==================================================
// ButtonBase.cs
// �ėp�I�ȃ{�^���̊��N���X
// ����m�F Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;
using UnityEngine.EventSystems;

namespace MyGameLib.UI
{
    public abstract class ButtonBase : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// �{�^�����������Ƃ��̏���
        /// </summary>
        public abstract void OnPointerClick(PointerEventData eventData);
    }
}
