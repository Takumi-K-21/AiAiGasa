// ==================================================
// SEManager.cs
// SE�̍Đ��Ȃǂ��Ǘ�����V���O���g���̃N���X
// ����m�F Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using UnityEngine;

namespace MyGameLib.Sound
{
    public class SEManager : MonoBehaviour
    {
        // �O������Q�Ƃ͂ł��邪�A����͂ł��Ȃ��V���O���g���̃C���X�^���X
        public static SEManager Instance { get; private set; }

        [SerializeField] private SoundDatabase _seDatabase;
        // SE�p��AudioSource
        private AudioSource _seAudioSource;

        // �V���O���g���̃C���X�^���X��������
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
                    Debug.LogError(gameObject.name + "��AudioSource������܂���", this);
                }

                if (_seDatabase == null)
                {
                    Debug.LogError(gameObject.name + "��SEDatabase������܂���", this);
                }
#endif
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// SE�̉��ʂ𒲐�����
        /// </summary>
        /// <param name="volume"> 0.0�`1.0�̒l </param>
        public void SetVolume(float volume)
        {
            // volume�̒l��0�`1�ɐ�������
            _seAudioSource.volume = Mathf.Clamp01(volume);
        }

        /// <summary>
        /// SE���Đ�����
        /// </summary>
        /// <param name="name"> �Đ�����SE�̖��O </param>
        public void Play(string name)
        {
            var seData = _seDatabase.Find(name);

#if UNITY_EDITOR
            if (seData == null)
            {
                Debug.LogError("SEData������܂���", this);
                return;
            }

            if (seData.Clip == null)
            {
                Debug.LogError(seData.Name + "��AudioClip������܂���", this);
                return;
            }
#endif

            _seAudioSource.PlayOneShot(seData.Clip, seData.Volume);
        }
    }
}
