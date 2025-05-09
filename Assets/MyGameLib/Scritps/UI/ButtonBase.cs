// ==================================================
// ButtonBase.cs
// 汎用的なボタンの基底クラス
// 動作確認 Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;
using UnityEngine.EventSystems;

namespace MyGameLib.UI
{
    public abstract class ButtonBase : MonoBehaviour, IPointerClickHandler
    {
        /// <summary>
        /// ボタンを押したときの処理
        /// </summary>
        public abstract void OnPointerClick(PointerEventData eventData);
    }
}
