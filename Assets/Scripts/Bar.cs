using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Bar
{
    private LevelData _levelData;
    private List<CardData> _cardDatas;

    public CardData TargetCardData { get; private set; }
    public IReadOnlyCollection<CardData> CardDatas => _cardDatas;

    public Bar(LevelData levelData)
    {
        if (levelData == null)
            throw new NullReferenceException(levelData.name);

        _levelData = levelData;
        _cardDatas = new List<CardData>();
    }

    public void Fill()
    {
        List<CardData> cardDatas = new List<CardData>();

        foreach (var cardData in _levelData.CardBundleData.CardDatas)
        {
            cardDatas.Add(cardData);
        }

        for (int i = 0; i < _levelData.Count; i++)
        {
            var randomNumber = Random.Range(0, _levelData.CardBundleData.CardDatas.Count);

            while (cardDatas[randomNumber] == null)
            {
                randomNumber = Random.Range(0, _levelData.CardBundleData.CardDatas.Count);
            }

            CardData cardData = cardDatas[randomNumber];

            _cardDatas.Add(cardData);

            cardDatas[randomNumber] = null;
        }

        AssignRandomTargetCardData();
    }

    public void AssignRandomTargetCardData()
    {
        TargetCardData =_cardDatas[Random.Range(0, _cardDatas.Count)];
    }
}
