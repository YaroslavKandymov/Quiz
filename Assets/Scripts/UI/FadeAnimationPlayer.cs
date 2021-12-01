using UnityEngine;
using DG.Tweening;
using TMPro;

public class FadeAnimationPlayer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private LoadLevelPanel _loadLevelPanel;


    private TMP_Text _text;

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
        _text = GetComponent<TMP_Text>();

        ChangeFade(1);
    }

    private void OnOpened()
    {
        _text.alpha = 0;
    }

    private void OnClosed()
    {
        ChangeFade(1);
    }

    private void ChangeFade(float value)
    {
        _text.DOFade(1, _duration);
    }
}
