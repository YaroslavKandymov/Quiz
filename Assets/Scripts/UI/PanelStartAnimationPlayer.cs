using UnityEngine;
using DG.Tweening;

public class PanelStartAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;
    [SerializeField] private LoadLevelPanel _loadLevelPanel;

    private void OnEnable()
    {
        _loadLevelPanel.Opened += OnOpened;
        _loadLevelPanel.Closed += OnClosed;
    }

    private void OnDisable()
    {
        _loadLevelPanel.Opened -= OnOpened;
        _loadLevelPanel.Closed -= OnClosed;
    }

    private void Start()
    {
        ChangeScale(_targetScale);
    }

    private void OnOpened()
    {
        transform.localScale = _startScale;
    }

    private void OnClosed()
    {
        ChangeScale(_targetScale);
    }

    private void ChangeScale(Vector3 scale)
    {
        transform.DOScale(scale, _duration).SetEase(_ease);
    }
}
