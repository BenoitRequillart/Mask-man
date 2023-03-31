using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButtonController : MonoBehaviour,
    IPointerDownHandler
{
    
    public event Action<bool> OnPressedFire;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("fire pressed");
        OnPressedFire?.Invoke(true);
    }
}
