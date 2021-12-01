using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    protected IPanelCloser PanelCloser;
    protected IPanelOpener PanelOpener;

    protected abstract void InitBehaviors();

    private void Awake()
    {
        InitBehaviors();
    }
}
