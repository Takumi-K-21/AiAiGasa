using UnityEngine;
using UnityEngine.EventSystems;
using MyGameLib.UI;

public class XButton : ButtonBase
{
    /// <summary>
    /// ƒ{ƒ^ƒ“‚ğ‰Ÿ‚µ‚½‚Æ‚«‚Ìˆ—
    /// </summary>
    public override void OnPointerClick(PointerEventData eventData)
    {
        naichilab.UnityRoomTweet.Tweet("aiaigasa", "P‚ğU‚è‰ñ‚µ‚Ä”Ş—‚ğç‚êI", "unityroom", "unity1week", "‘Š‡‚¢P");
    }
}