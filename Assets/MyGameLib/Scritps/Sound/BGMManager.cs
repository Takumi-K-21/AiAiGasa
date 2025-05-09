// ==================================================
// BGMManager.cs
// BGM�̍Đ��Ȃǂ��Ǘ�����V���O���g���̃N���X
// ����m�F Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;

namespace MyGameLib.Sound
{
    public class BGMManager : MonoBehaviour
    {
        // �O������Q�Ƃ͂ł��邪�A����͂ł��Ȃ��V���O���g���̃C���X�^���X
        public static BGMManager Instance { get; private set; }

        [SerializeField] private SoundDatabase _bgmDatabase;
        // BGM�p��AudioSource
        private AudioSource _bgmAudioSource;

        // AudioSource�̉���
        private float _bgmMasterVolume = 1f;
        // BGMData�̉���
        private float _bgmDataVolume = 1f;

        // �V���O���g���̃C���X�^���X��������
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
                    Debug.LogError(gameObject.name + "��AudioSource������܂���", this);
                }

                if (_bgmDatabase == null)
                {
                    Debug.LogError(gameObject.name + "��BGMDatabase������܂���", this);
                }
#endif
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// BGM�̉��ʂ𒲐�����
        /// </summary>
        /// <param name="volume"> 0.0�`1.0�̒l </param>
        public void SetVolume(float volume)
        {
            // volume�̒l��0.0�`1.0�ɐ�������
            _bgmMasterVolume = Mathf.Clamp01(volume);
            _bgmAudioSource.volume = Mathf.Clamp01(_bgmMasterVolume * _bgmDataVolume);
        }

        /// <summary>
        /// BGM���Đ�����
        /// </summary>
        /// <param name="name"> �Đ�����BGM�̖��O </param>
        public void Play(string name)
        {
            var bgmData = _bgmDatabase.Find(name);

#if UNITY_EDITOR
            if (bgmData == null)
            {
                Debug.LogError("BGMData������܂���", this);
                return;
            }

            if (bgmData.Clip == null)
            {
                Debug.LogError(bgmData.Name + "��AudioClip������܂���", this);
                return;
            }
#endif

            // BGM��ݒ肷��
            _bgmAudioSource.Stop();
            _bgmAudioSource.clip = bgmData.Clip;
            _bgmDataVolume = Mathf.Clamp01(bgmData.Volume);
            _bgmAudioSource.volume = Mathf.Clamp01(_bgmMasterVolume * _bgmDataVolume);
            _bgmAudioSource.Play();
        }

        /// <summary>
        /// BGM���~����
        /// </summary>
        public void Stop()
        {
            _bgmAudioSource.Stop();
        }
    }
}
