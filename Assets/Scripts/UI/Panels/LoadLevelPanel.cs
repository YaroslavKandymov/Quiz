using System;
using UnityEngine;

public class LoadLevelPanel : Panel
{
    [SerializeField] private RestartPanel _restartPanel;
    [SerializeField] private LoadPanelAnimationPlayer _loadPanelAnimationPlayer;

    public event Action Opened;
    public event Action Closed;

    private void OnEnable()
    {
        _restartPanel.Restarted += OnRestarted;
        _loadPanelAnimationPlayer.Ended += OnEnded;
    }

    private void OnDisable()
    {
        _restartPanel.Restarted -= OnRestarted;
        _loadPanelAnimationPlayer.Ended -= OnEnded;
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

    private void OnRestarted()
    {
        PanelOpener.Open(this);
        Opened?.Invoke();
    }

    private void OnEnded()
    {
        PanelCloser.Close(this);
        Closed?.Invoke();
    }
}
