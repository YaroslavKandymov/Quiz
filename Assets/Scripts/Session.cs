using System;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levelDatas;
    [SerializeField] private BarView _barView;

    private int _length;
    private int _winCounter;

    public event Action Ended;

    private void OnEnable()
    {
        _barView.CorrectTargetClicked += OnCorrectTargetClicked;
    }

    private void OnDisable()
    {
        _barView.CorrectTargetClicked -= OnCorrectTargetClicked;
    }

    private void Start()
    {
        _length = _levelDatas.Count;
    }

    private void OnCorrectTargetClicked(Cell cell)
    {
        _winCounter++;

        if(_winCounter % _length == 0)
            Ended?.Invoke();
    }
}
