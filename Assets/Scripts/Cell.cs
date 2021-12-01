using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image _image;

    public event Action<Cell> Clicked;

    public void Init(Sprite sprite)
    {
        if(sprite == null)
            throw new NullReferenceException(sprite.name);

        _image.sprite = sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked?.Invoke(this);
    }
}

