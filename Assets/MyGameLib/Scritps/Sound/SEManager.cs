// ==================================================
// SEManager.cs
// SEの再生などを管理するシングルトンのクラス
// 動作確認 Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;

namespace MyGameLib.Sound
{
    public class SEManager : MonoBehaviour
    {
        // 外部から参照はできるが、代入はできないシングルトンのインスタンス
        public static SEManager Instance { get; private set; }

        [SerializeField] private SoundDatabase _seDatabase;
        // SE用のAudioSource
        private AudioSource _seAudioSource;

        // シングルトンのインスタンスを初期化
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                _seAudioSource = GetComponent<AudioSource>();

#if UNITY_EDITOR
                if (_seAudioSource == null)
                {
                    Debug.LogError(gameObject.name + "にAudioSourceがありません", this);
                }

                if (_seDatabase == null)
                {
                    Debug.LogError(gameObject.name + "にSEDatabaseがありません", this);
                }
#endif
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// SEの音量を調整する
        /// </summary>
        /// <param name="volume"> 0.0～1.0の値 </param>
        public void SetVolume(float volume)
        {
            // volumeの値を0～1に制限する
            _seAudioSource.volume = Mathf.Clamp01(volume);
        }

        /// <summary>
        /// SEを再生する
        /// </summary>
        /// <param name="name"> 再生するSEの名前 </param>
        public void Play(string name)
        {
            var seData = _seDatabase.Find(name);

#if UNITY_EDITOR
            if (seData == null)
            {
                Debug.LogError("SEDataがありません", this);
                return;
            }

            if (seData.Clip == null)
            {
                Debug.LogError(seData.Name + "にAudioClipがありません", this);
                return;
            }
#endif

            _seAudioSource.PlayOneShot(seData.Clip, seData.Volume);
        }
    }
}
