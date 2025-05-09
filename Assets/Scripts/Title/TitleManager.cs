using UnityEngine;
using MyGameLib.Sound;

public class TitleManager : MonoBehaviour
{
    private void Start()
    {
        BGMManager.Instance.Play("Title");
    }
}
