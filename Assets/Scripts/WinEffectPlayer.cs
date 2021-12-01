using UnityEngine;

public class WinEffectPlayer : ParticleSystemPlayer
{
    [SerializeField] private BarView _barView;

    private void OnEnable()
    {
        _barView.CorrectTargetClicked += OnCorrectTargetClicked;
    }

    private void OnDisable()
    {
        _barView.CorrectTargetClicked -= OnCorrectTargetClicked;
    }

    private void OnCorrectTargetClicked(Cell cell)
    {
        PlayEffect(cell.transform);
    }
}
