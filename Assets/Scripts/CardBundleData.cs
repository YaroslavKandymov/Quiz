using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle LevelData", order = 51)]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private CardData[] _cardDatas;

    public IReadOnlyCollection<CardData> CardDatas => _cardDatas;
}
