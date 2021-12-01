using System;
using UnityEngine;
using UnityEngine.UI;

public class RestartPanel : Panel
{
    [SerializeField] private Session _session;
    [SerializeField] private Button _restartButton;

    public event Action SessionEnded;
    public event Action Restarted;

    private void OnEnable()
    {
        _session.Ended += OnEnded;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _session.Ended -= OnEnded;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void Start()
    {
        PanelCloser.Close(this);
    }

    protected override void InitBehaviors()
    {
        PanelOpener = new OpenPanelBehavior();
        PanelCloser = new ClosePanelBehavior();
    }

    private void OnEnded()
    {
        PanelOpener.Open(this);
        SessionEnded?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        Restarted?.Invoke();
        PanelCloser.Close(this);
    }
}
