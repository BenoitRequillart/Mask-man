using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonController : MonoBehaviour,
    IPointerDownHandler
{

    public event Action<bool> OnPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressed?.Invoke(true);
    }
}
