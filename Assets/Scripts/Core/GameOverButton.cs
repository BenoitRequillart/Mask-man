using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField]
    private GameManager gameManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        gameManager.Restart();
        Debug.Log("Restart");
    }
}
