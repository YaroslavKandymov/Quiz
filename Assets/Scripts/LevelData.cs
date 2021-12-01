using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 52)]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _count;
    [SerializeField] private CardBundleData _cardBundleData;

    public int Count => _count;
    public CardBundleData CardBundleData => _cardBundleData;
}
