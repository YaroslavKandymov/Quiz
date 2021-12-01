using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RestartPanelAnimationPlayer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private RestartPanel _restartPanel;
    [SerializeField] private float _fadeInValue;

    private Image _image;

    private void OnEnable()
    {
        _restartPanel.SessionEnded += OnSessionEnded;
        _restartPanel.Restarted += OnRestarted;
    }

    private void OnDisable()
    {
        _restartPanel.SessionEnded -= OnSessionEnded;
        _restartPanel.Restarted -= OnRestarted;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void OnSessionEnded()
    {
        SetTargetFade(_fadeInValue);
    }

    private void OnRestarted()
    {
        SetTargetFade(0);
    }

    private void SetTargetFade(float value)
    {
        _image.DOFade(value, _duration);
    }
}
