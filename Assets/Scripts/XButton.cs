using UnityEngine;
using UnityEngine.EventSystems;
using MyGameLib.UI;

public class XButton : ButtonBase
{
    /// <summary>
    /// ボタンを押したときの処理
    /// </summary>
    public override void OnPointerClick(PointerEventData eventData)
    {
        naichilab.UnityRoomTweet.Tweet("aiaigasa", "傘を振り回して彼女を守れ！", "unityroom", "unity1week", "相合い傘");
    }
}