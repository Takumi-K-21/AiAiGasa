using UnityEngine;
using UnityEngine.EventSystems;
using MyGameLib.UI;

public class XButton : ButtonBase
{
    /// <summary>
    /// �{�^�����������Ƃ��̏���
    /// </summary>
    public override void OnPointerClick(PointerEventData eventData)
    {
        naichilab.UnityRoomTweet.Tweet("aiaigasa", "�P��U��񂵂Ĕޏ������I", "unityroom", "unity1week", "�������P");
    }
}