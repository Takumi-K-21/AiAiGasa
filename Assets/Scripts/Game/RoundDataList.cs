using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundDataList", menuName = "Game/RoundDataList", order = 1)]
public class RoundDataList : ScriptableObject
{
    [SerializeField] private List<RoundData> _roundDataList;

    public List<RoundData> Round => _roundDataList;
    public int Count => _roundDataList.Count;
}
