using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonController : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField]
    private GameManager gameManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        gameManager.LoadStage();
    }
}
