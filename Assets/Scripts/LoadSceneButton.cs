using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using MyGameLib.Sound;
using MyGameLib.UI;

public class LoadSceneButton : ButtonBase
{
    [SerializeField] private float _fadeTime = 1f;
    [SerializeField] private string _nextScene;

    /// <summary>
    /// ƒ{ƒ^ƒ“‚ğ‰Ÿ‚µ‚½‚Æ‚«‚Ìˆ—
    /// </summary>
    public override void OnPointerClick(PointerEventData eventData)
    {
        BGMManager.Instance.Stop();
        FadeManager.Instance.LoadScene(_nextScene, _fadeTime);
    }
}