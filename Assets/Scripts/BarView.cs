using System;
using System.Collections.Generic;
using UnityEngine;

public class BarView : MonoBehaviour
{
    [SerializeField] private Cell _cellTemplate;
    [SerializeField] private LevelData[] _levelDatas;
    [SerializeField] private LoadLevelPanel _loadLevelPanel;

    private readonly Queue<LevelData> _levelDatasQueue = new Queue<LevelData>();
    private string _purposeCellName;
    private readonly List<Cell> _cells = new List<Cell>();
    private Cell _targetCell;
    private LevelData _currentLevelData;
    private int _correctClickCounter;
    private List<CardData> _correctCells = new List<CardData>();

    public event Action<Cell> CorrectTargetClicked;
    public event Action<Cell> WrongTargetClicked;
    public event Action<string> PurposeCellChanged;

    public string PurposeCellName => _purposeCellName;

    private void Awake()
    {
        foreach (var levelData in _levelDatas)
        {
            _levelDatasQueue.Enqueue(levelData);
        }

        CreateNext();
    }

    private void OnEnable()
    {
        _loadLevelPanel.Opened += OnOpened;
    }

    private void OnDisable()
    {
        _loadLevelPanel.Opened -= OnOpened;
    }

    private void Create(LevelData levelData)
    {
        Bar bar = new Bar(levelData);
        bar.Fill();

        while (_correctCells.Contains(bar.TargetCardData))
        {
            bar.AssignRandomTargetCardData();
        }

        _purposeCellName = bar.TargetCardData.Identifier;
        PurposeCellChanged?.Invoke(_purposeCellName);

        foreach (var cardData in bar.CardDatas)
        {
            var cell = _cellTemplate;

            cell.Init(cardData.Sprite);

            var newCell = Instantiate(cell, transform);

            if (bar.TargetCardData == cardData)
            {
                _targetCell = newCell;
                _correctCells.Add(cardData);
            }

            _cells.Add(newCell);
        }

        foreach (var cell in _cells)
        {
            cell.Clicked += OnClicked;
        }
    }

    private void Clean()
    {
        foreach (var cell in _cells)
        {
            cell.Clicked -= OnClicked;
            Destroy(cell.gameObject);
        }

        _cells.Clear();
    }

    private void CreateNext()
    {
        if (_currentLevelData != null)
            Clean();

        _currentLevelData = _levelDatasQueue.Dequeue();
        Create(_currentLevelData);
        _levelDatasQueue.Enqueue(_currentLevelData);
    }

    private void OnClicked(Cell cell)
    {
        if (cell == _targetCell)
        {
            _correctClickCounter++;
            CorrectTargetClicked?.Invoke(cell);

            if (_correctClickCounter % _levelDatasQueue.Count == 0)
                return;

            CreateNext();
        }
        else
        {
            WrongTargetClicked?.Invoke(cell);
        }
    }

    private void OnOpened()
    {
        CreateNext();
    }
}