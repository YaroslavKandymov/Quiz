using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LoadPanelAnimationPlayer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _lifetime;

    private Image _image;

    public event Action Ended;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void PlayAnimation()
    {
        StartCoroutine(PlayAnimationCoroutine());
    }

    private IEnumerator PlayAnimationCoroutine()
    {
        _image.DOFade(1, _duration);

        yield return new WaitForSeconds(_lifetime);

        _image.DOFade(0, _duration);

        Ended?.Invoke();
    }
}
