// ==================================================
// SoundData.cs
// Sound�̐ݒ�(���O�A�����A����)���Ǘ�����N���X
// ����m�F Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;

namespace MyGameLib.Sound
{
    [System.Serializable]
    public class SoundData
    {
        // ���O
        [SerializeField] private string _name;
        // ����
        [SerializeField] private AudioClip _clip;
        // ����
        [SerializeField, Range(0f, 1f)] private float _volume;

        public string Name => _name;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
    }
}
