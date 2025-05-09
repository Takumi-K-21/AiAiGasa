// ==================================================
// SoundData.cs
// Soundの設定(名前、音声、音量)を管理するクラス
// 動作確認 Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;

namespace MyGameLib.Sound
{
    [System.Serializable]
    public class SoundData
    {
        // 名前
        [SerializeField] private string _name;
        // 音声
        [SerializeField] private AudioClip _clip;
        // 音量
        [SerializeField, Range(0f, 1f)] private float _volume;

        public string Name => _name;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
    }
}
