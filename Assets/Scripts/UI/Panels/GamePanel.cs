using UnityEngine;

public class GamePanel : Panel
{
    [SerializeField] private RestartPanel _restartPanel;
    [SerializeField] private LoadLevelPanel _loadLevelPanel;

    private void OnEnable()
    {
        _restartPanel.Restarted += OnRestarted;
        _loadLevelPanel.Closed += OnClosed;
    }

    private void OnDisable()
    {
        _restartPanel.Restarted -= OnRestarted;
        _loadLevelPanel.Closed -= OnClosed;
    }

    private void Start()
    {
        PanelOpener.Open(this);
    }

    protected override void InitBehaviors()
    {
        PanelOpener = new OpenPanelBehavior();
        PanelCloser = new ClosePanelBehavior();
    }

    private void OnRestarted()
    {
        PanelOpener.Open(this);
    }

    private void OnClosed()
    {
        PanelOpener.Open(this);
    }
}
