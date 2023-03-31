using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoyastickController : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler, IDragHandler

{
    private RectTransform joystickTransform;

    [SerializeField]
    private float dragMovementDistance = 50;

    [SerializeField]
    private float dragOffsetDistance = 100;


    public event Action<Vector2> OnMove;

    private void Awake()
    {
        joystickTransform = (RectTransform)transform;
    }



    public void OnDrag(PointerEventData eventData)
    {

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickTransform,
            eventData.position,
            null,
            out Vector2 movement
            );

        movement = Vector2.ClampMagnitude(movement, dragOffsetDistance) / dragOffsetDistance;

        joystickTransform.anchoredPosition = movement * dragMovementDistance;

        OnMove?.Invoke(movement);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTransform.anchoredPosition = Vector2.zero;
        OnMove?.Invoke(Vector2.zero);
    }
}
