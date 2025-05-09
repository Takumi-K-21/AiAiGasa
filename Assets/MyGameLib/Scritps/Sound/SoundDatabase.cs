// ==================================================
// SoundDatabase.cs
// SoundDataをデータベースで管理するクラス
// 動作確認 Unity 2022.3.61f1
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

        // データベースの初期化
        private void OnEnable()
        {
            // SoundDataの名前で検索できるようにListからDictionaryに変換する
            foreach (var soundData in _soundDataList)
            {
#if UNITY_EDITOR
                if (soundData == null)　Debug.LogError("SoundDataがありません", this);
                if (string.IsNullOrEmpty(soundData.Name)) Debug.LogError("SoundDataに名前がありません", this);
                if (soundData.Clip == null)　Debug.LogWarning("SoundDataに音声がありません", this);
                if (_soundDataDictionary.ContainsKey(soundData.Name)) Debug.LogWarning(soundData.Name + "は登録されています", this);
#endif

                _soundDataDictionary[soundData.Name] = soundData;
            }
        }

        /// <summary>
        /// データベースから指定された名前のSoundDataを取得する
        /// </summary>
        /// <param name="name"> SoundDataの名前 </param>
        /// <returns> 取得できたらSoundData、取得できなかったらnullを返す </returns>
        public SoundData Find(string name)
        {
            if (_soundDataDictionary.TryGetValue(name, out var soundData)) return soundData;

#if UNITY_EDITOR
            Debug.LogError(name + "はSoundDataにありません", this);
#endif

            return null;
        }
    }
}
