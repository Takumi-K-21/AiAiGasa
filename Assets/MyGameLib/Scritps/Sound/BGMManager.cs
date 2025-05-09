// ==================================================
// BGMManager.cs
// BGMの再生などを管理するシングルトンのクラス
// 動作確認 Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;

namespace MyGameLib.Sound
{
    public class BGMManager : MonoBehaviour
    {
        // 外部から参照はできるが、代入はできないシングルトンのインスタンス
        public static BGMManager Instance { get; private set; }

        [SerializeField] private SoundDatabase _bgmDatabase;
        // BGM用のAudioSource
        private AudioSource _bgmAudioSource;

        // AudioSourceの音量
        private float _bgmMasterVolume = 1f;
        // BGMDataの音量
        private float _bgmDataVolume = 1f;

        // シングルトンのインスタンスを初期化
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                _bgmAudioSource = GetComponent<AudioSource>();

#if UNITY_EDITOR
                if (_bgmAudioSource == null)
                {
                    Debug.LogError(gameObject.name + "にAudioSourceがありません", this);
                }

                if (_bgmDatabase == null)
                {
                    Debug.LogError(gameObject.name + "にBGMDatabaseがありません", this);
                }
#endif
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// BGMの音量を調整する
        /// </summary>
        /// <param name="volume"> 0.0～1.0の値 </param>
        public void SetVolume(float volume)
        {
            // volumeの値を0.0～1.0に制限する
            _bgmMasterVolume = Mathf.Clamp01(volume);
            _bgmAudioSource.volume = Mathf.Clamp01(_bgmMasterVolume * _bgmDataVolume);
        }

        /// <summary>
        /// BGMを再生する
        /// </summary>
        /// <param name="name"> 再生するBGMの名前 </param>
        public void Play(string name)
        {
            var bgmData = _bgmDatabase.Find(name);

#if UNITY_EDITOR
            if (bgmData == null)
            {
                Debug.LogError("BGMDataがありません", this);
                return;
            }

            if (bgmData.Clip == null)
            {
                Debug.LogError(bgmData.Name + "にAudioClipがありません", this);
                return;
            }
#endif

            // BGMを設定する
            _bgmAudioSource.Stop();
            _bgmAudioSource.clip = bgmData.Clip;
            _bgmDataVolume = Mathf.Clamp01(bgmData.Volume);
            _bgmAudioSource.volume = Mathf.Clamp01(_bgmMasterVolume * _bgmDataVolume);
            _bgmAudioSource.Play();
        }

        /// <summary>
        /// BGMを停止する
        /// </summary>
        public void Stop()
        {
            _bgmAudioSource.Stop();
        }
    }
}
