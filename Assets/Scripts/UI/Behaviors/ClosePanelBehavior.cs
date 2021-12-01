using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClosePanelBehavior : IPanelCloser
{
    public void Close(Panel panel, float duration = 0)
    {
        var canvasGroup = panel.GetComponent<CanvasGroup>();
        var buttons = panel.GetComponentsInChildren<Button>();

        canvasGroup.DOFade(0, duration);
        canvasGroup.blocksRaycasts = false;

        foreach (var button in buttons)
            button.interactable = false;
    }
}
