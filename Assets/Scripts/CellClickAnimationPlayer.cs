using DG.Tweening;
using UnityEngine;

public class CellClickAnimationPlayer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private BarView _barView;
    [SerializeField] private Ease _correctTargetEase;
    [SerializeField] private Ease _wrongTargetEase;

    private void OnEnable()
    {
        _barView.CorrectTargetClicked += OnCorrectTargetClicked;
        _barView.WrongTargetClicked += OnWrongTargetClicked;
    }

    private void OnDisable()
    {
        _barView.CorrectTargetClicked -= OnCorrectTargetClicked;
        _barView.WrongTargetClicked -= OnWrongTargetClicked;
    }

    private void OnCorrectTargetClicked(Cell cell)
    {
        Play(cell.transform, _correctTargetEase);
    }

    private void OnWrongTargetClicked(Cell cell)
    {
        Play(cell.transform, _wrongTargetEase);
    }

    private void Play(Transform cell, Ease ease)
    {
        cell.DOMove(cell.position + _offset, _duration).SetEase(ease).OnComplete(() => cell.DOMove(cell.position - _offset, 0));
    }
}
