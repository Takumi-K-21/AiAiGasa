// ==================================================
// SoundDatabase.cs
// SoundData���f�[�^�x�[�X�ŊǗ�����N���X
// ����m�F Unity 2022.3.61f1
// (C) 2025 Takumi Kato
// ==================================================

using System.Collections.Generic;
using UnityEngine;

namespace MyGameLib.Sound
{
    [CreateAssetMenu(menuName = "MyGameLib/Sound/SoundDatabase")]
    public class SoundDatabase : ScriptableObject
    {
        [SerializeField] private List<SoundData> _soundDataList;
        private Dictionary<string, SoundData> _soundDataDictionary = new Dictionary<string, SoundData>();

        // �f�[�^�x�[�X�̏�����
        private void OnEnable()
        {
            // SoundData�̖��O�Ō����ł���悤��List����Dictionary�ɕϊ�����
            foreach (var soundData in _soundDataList)
            {
#if UNITY_EDITOR
                if (soundData == null)�@Debug.LogError("SoundData������܂���", this);
                if (string.IsNullOrEmpty(soundData.Name)) Debug.LogError("SoundData�ɖ��O������܂���", this);
                if (soundData.Clip == null)�@Debug.LogWarning("SoundData�ɉ���������܂���", this);
                if (_soundDataDictionary.ContainsKey(soundData.Name)) Debug.LogWarning(soundData.Name + "�͓o�^����Ă��܂�", this);
#endif

                _soundDataDictionary[soundData.Name] = soundData;
            }
        }

        /// <summary>
        /// �f�[�^�x�[�X����w�肳�ꂽ���O��SoundData���擾����
        /// </summary>
        /// <param name="name"> SoundData�̖��O </param>
        /// <returns> �擾�ł�����SoundData�A�擾�ł��Ȃ�������null��Ԃ� </returns>
        public SoundData Find(string name)
        {
            if (_soundDataDictionary.TryGetValue(name, out var soundData)) return soundData;

#if UNITY_EDITOR
            Debug.LogError(name + "��SoundData�ɂ���܂���", this);
#endif

            return null;
        }
    }
}
